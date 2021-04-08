using NLog;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf.Core;
using Topshelf.Domain.Services;

namespace Topshelf.Quartz.Jobs
{
    public class MyJob : IJob
    {
        private readonly IUserService _service;
        private readonly INLogger _logger;
        public MyJob(IUserService service, INLogger logger)
        {
            this._service = service;
            this._logger = logger;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            _logger.Info("123");
            Console.WriteLine($"{DateTime.Now} - {_service.GetName()?.FirstOrDefault()?.name} - {context.CancellationToken}");
            await Task.CompletedTask;
        }
    }
}
