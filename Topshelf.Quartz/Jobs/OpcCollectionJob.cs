using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf.Core;

namespace Topshelf.Quartz.Jobs
{
    public class OpcCollectionJob : IJob
    {
        private readonly INLogger _logger;
        public OpcCollectionJob(INLogger logger)
        {
            _logger = logger;
        }


        public async Task Execute(IJobExecutionContext context)
        {
            try
            {

            }
            catch(Exception ex)
            {
                _logger.Warn(ex.ToString());
            }
            await Task.CompletedTask;
        }



    }
}
