using Quartz;
using System;
using Quartz.Impl;

using TaxiCompany.DataAccess.Persistence;
using Quartz.Spi;

namespace TaxiCompany.API.RabbitMQ
{

//    public static class QuartzSetup
//    {
//        public static void AddQuartzSetup(this IServiceCollection services)
//        {

//            services.AddQuartz(q =>
//            {
//                q.UseMicrosoftDependencyInjectionJobFactory();
//            });


//            services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);
//            services.AddScoped<RabbitMqLogHandler>();

//        }
//        public static void ConfigureQuartzJobs(IServiceProvider serviceProvider)
//        {
//            var scheduler = serviceProvider.GetRequiredService<IScheduler>();
//            var jobfactory = serviceProvider.GetRequiredService<IJobFactory>();
//            scheduler.JobFactory = jobfactory;
//            var job = JobBuilder.Create<RabbitMqLogHandler>()
//                                .WithIdentity("LogEntryJob", "Group1")
//                                .Build();

//            var trigger = TriggerBuilder.Create()
//                                        .WithIdentity("LogEntryJobTrigger", "Group1")
//                                        .StartNow()
//                                        .WithSimpleSchedule(x => x.WithIntervalInMinutes(1).RepeatForever())
//                                        .Build();

//            scheduler.ScheduleJob(job, trigger);
//        }
//    }


}
