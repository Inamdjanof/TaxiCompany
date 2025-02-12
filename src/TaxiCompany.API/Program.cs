using FluentValidation;
using FluentValidation.AspNetCore;
using Quartz.Spi;
using Quartz;
using TaxiCompany.API;
using TaxiCompany.API.Extensions;
using TaxiCompany.API.Filters;
using TaxiCompany.API.Middleware;
using TaxiCompany.API.RabbitMQ;
using TaxiCompany.Application;
using TaxiCompany.Application.Models.Validators;
using TaxiCompany.DataAccess;
using TaxiCompany.DataAccess.Authentication;
using TaxiCompany.DataAccess.Persistence;
using Quartz.Impl;
using TaxiCompany.API.Quartz;
using TaxiCompany.DataAccess.Repositories.Impl;
using TaxiCompany.DataAccess.Repositories;
using TaxiCompany.Application;
using MediatR;

var builder = WebApplication.CreateBuilder(args);
    
     builder.AddLogging(builder.Configuration);

     builder.Services
    .AddDbContexts(builder.Configuration)
    .AddAuthentication(builder.Configuration)
    .AddInfrastructure()
    .AddApplication();

builder.Services.AddControllers(
    config => config.Filters.Add(typeof(ValidateModelAttribute))
);





builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Admin", policy =>
        policy.RequireClaim(CustomClaimNames.Role, "Admin"));
    options.AddPolicy("Driver", policy =>
        policy.RequireClaim(CustomClaimNames.Role, "Driver"));
    options.AddPolicy("Client", policy =>
        policy.RequireClaim(CustomClaimNames.Role, "Client"));

});

// quartz

builder.Services.AddQuartz(q =>
{
    q.UseMicrosoftDependencyInjectionJobFactory();
    var jobKey = new JobKey("RabbitMqLogJob");
    q.AddJob<RabbitMqLogHandler>(opts => opts.WithIdentity(jobKey));

    q.AddTrigger(opts => opts
        .ForJob(jobKey)
        .WithIdentity("RabbitMqLogTrigger")
        .StartNow()
        .WithSimpleSchedule(x => x.WithIntervalInSeconds(5).RepeatForever()));
});

builder.Services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);

builder.Services.AddTransient<RabbitMqLogHandler>();

//

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ApplicationAssemblyMarker).Assembly));

builder.Services.AddScoped<IBankRepository, BankRepository>();
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();



builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining(typeof(IValidationsMarker));


builder.Services.AddSwagger();

builder.Services.AddHttpContextAccessor();

builder.Services.AddDataAccess(builder.Configuration)
    .AddApplication(builder.Environment);


builder.Services.AddEmailConfiguration(builder.Configuration);

var app = builder.Build();



using var scope = app.Services.CreateScope();




await AutomatedMigration.MigrateAsync(scope.ServiceProvider);

app.UseSwagger();
app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "TaxiCompany V1"); });

app.UseHttpsRedirection();

app.UseCors(corsPolicyBuilder =>
    corsPolicyBuilder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader()
);

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.UseMiddleware<MiddlewareRabbitMQ>();

app.UseMiddleware<PerformanceMiddleware>();

app.UseMiddleware<TransactionMiddleware>();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseMiddleware<GlobalExceptionHandlingMiddleware>();

app.MapControllers();



app.Run();







namespace TaxiCompany.API
{
    public partial class Program { }
}






