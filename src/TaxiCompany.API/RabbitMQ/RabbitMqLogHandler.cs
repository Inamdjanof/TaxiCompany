using Microsoft.EntityFrameworkCore;
using Quartz;
using Quartz.Impl;
using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System.Threading.Tasks;
using TaxiCompany.DataAccess.Persistence;
using System.Text;
using TaxiCompany.Core.Entities;

namespace TaxiCompany.API.Quartz
{
    public class RabbitMqLogHandler : IJob
    {
         private readonly IServiceProvider _serviceProvider;
            private readonly ILogger<RabbitMqLogHandler> _logger;
            private readonly string _queueName = "logs";
            private readonly IConnection _connection;
            private readonly IModel _channel;

            public RabbitMqLogHandler(IServiceProvider serviceProvider, ILogger<RabbitMqLogHandler> logger)
            {
                _serviceProvider = serviceProvider;
                _logger = logger;

                var factory = new ConnectionFactory() { HostName = "localhost" };
                _connection = factory.CreateConnection();
                _channel = _connection.CreateModel();
                _channel.QueueDeclare(queue: _queueName, durable: true, exclusive: false, autoDelete: false, arguments: null);
            }

            public async Task Execute(IJobExecutionContext context)
            {
                _logger.LogInformation("RabbitMqLogHandler job started...");

                using var scope = _serviceProvider.CreateScope();
                var dbContext = scope.ServiceProvider.GetRequiredService<DatabaseContext>();

                var result = _channel.BasicGet(_queueName, autoAck: true);

                if (result != null)
                {
                    try
                    {
                        var body = result.Body.ToArray();
                        var message = Encoding.UTF8.GetString(body);
                        _logger.LogInformation($"Received RabbitMQ message: {message}");

                        var parts = message.Split(new[] { "Response:" }, StringSplitOptions.None);
                        var request = parts[0].Replace("Request:", "").Trim();
                        var response = parts.Length > 1 ? parts[1].Trim() : "";

                        var logEntry = new LogEntry
                        {
                            Request = request,
                            Response = response,
                            CreatedAt = DateTime.UtcNow
                        };

                        dbContext.LogEntries.Add(logEntry);
                        await dbContext.SaveChangesAsync();
                        _logger.LogInformation("Log saved to database.");
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError($"Error processing RabbitMQ message: {ex.Message}");
                    }
                }
                else
                {
                    _logger.LogInformation("No new messages in RabbitMQ.");
                }
            }
        }

    }

