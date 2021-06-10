using Alexinea.Autofac.Extensions.DependencyInjection;
using Autofac;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;
using Topshelf.Core;
using Topshelf.EFCore;
using Topshelf.Infrastructure;

namespace Topshelf.Quartz
{
    public static class ServicesExtensions
    {
        internal static ContainerBuilder ConfigureSelf(this ContainerBuilder builder)
        {
            var services = new ServiceCollection();
            services.Configure<DbContextOption>(options =>
            {
                options.ConnectionString = Settings.Instance.Configuration["SqlserverString"];
                options.ModelAssemblyName = "Topshelf.Models";
                options.IsOutputSql = false;
            });
            services.AddScoped<IDbContextCore, SqlServerDBContext>();
            builder.Populate(services);
            var assembly = Assembly.Load("Topshelf.Domain");
            builder.RegisterAssemblyTypes(assembly)
                   .Where(t => t.Name.EndsWith("Repository", StringComparison.OrdinalIgnoreCase))
                   .AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(assembly)
                   .Where(t => t.Name.EndsWith("Services", StringComparison.OrdinalIgnoreCase))
                   .AsImplementedInterfaces().PropertiesAutowired();
            return builder;
        }
    }
}
