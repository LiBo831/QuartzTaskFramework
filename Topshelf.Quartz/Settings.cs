﻿using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace Topshelf.Core
{
    public class Settings
    {
        private static readonly Lazy<Settings> _instance = new Lazy<Settings>(() => new Settings());

        public static Settings Instance => _instance.Value;

        public IConfigurationRoot Configuration { get; }

        private Settings()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            Configuration = builder.Build();
        }

        public string CsvPath => Configuration["CSVPath"];

        public string ServiceName => Configuration["ServiceName"];

        public string ServiceDisplayName => Configuration["ServiceDisplayName"];

        public string ServiceDescription => Configuration["ServiceDescription"];

        public string JobNamespceFormat => Configuration["Jobs.Namespace"];

        public List<Jobdetail> JobList => Configuration.GetSection("JobList").Get<List<Jobdetail>>();

    }
}
