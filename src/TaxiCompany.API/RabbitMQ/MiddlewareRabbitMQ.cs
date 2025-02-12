using Microsoft.EntityFrameworkCore.Metadata;
using RabbitMQ.Client;
using System.Text;
using IModel = RabbitMQ.Client.IModel;

namespace TaxiCompany.API.RabbitMQ
{
    public class MiddlewareRabbitMQ
    {
        private readonly RequestDelegate _next;
        private readonly IModel _channel;

        public MiddlewareRabbitMQ(RequestDelegate next)
        {
            _next = next;

            var factory = new ConnectionFactory() { HostName = "localhost" };
            var connection = factory.CreateConnection();
            _channel = connection.CreateModel();
            _channel.QueueDeclare(
                     queue: "logs",
                     durable: true,
                     exclusive: false,
                     autoDelete: false,
                     arguments: null
                );
        }

         public async Task Invoke(HttpContext context)
        {
            var requestLog = await GetRequestLog(context);

            var  originalResponseBodyStream = context.Response.Body;
            using (var responseBody = new MemoryStream())
            {
                context.Response.Body = responseBody;
                await _next(context);

                var responseLog = await GetResponseLog(context);
                await responseBody.CopyToAsync(originalResponseBodyStream);

                PublishToRabbitMQ("Request: " + requestLog);
                PublishToRabbitMQ("Response: " + responseLog);
            }
        }

         private async Task<string> GetRequestLog(HttpContext context)
        {
            context.Request.EnableBuffering();
            var buffer = new byte[Convert.ToInt32(context.Request.ContentLength)];
            await context.Request.Body.ReadAsync(buffer, 0, buffer.Length);
            var requestBody = Encoding.UTF8.GetString(buffer);
            context.Request.Body.Position=0;
            return $"Method: {context.Request.Method}, Path: {context.Request.Path}";
        }

        private async Task<string> GetResponseLog(HttpContext context)
        {
            context.Response.Body.Seek(0, SeekOrigin.Begin);
            var responseBody = await new StreamReader(context.Response.Body).ReadToEndAsync();
            context.Response.Body.Seek(0, SeekOrigin.Begin);
            return $"Status Code: {context.Response.StatusCode}";
        }

        private void PublishToRabbitMQ(string message)
        {
            var body = Encoding.UTF8.GetBytes(message);
            _channel.BasicPublish(
                exchange: "",
                routingKey: "logs",
                basicProperties: null,
                body: body
            );
        }



    }
}
