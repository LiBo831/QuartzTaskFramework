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
        public INLogger _logger { get; set; }

        public async Task Execute(IJobExecutionContext context)
        {
            //try
            //{

            //}
            //catch(Exception ex)
            //{
            //    _logger.Warn(ex.ToString());
            //}

            await Task.CompletedTask;
        }



    }
}
