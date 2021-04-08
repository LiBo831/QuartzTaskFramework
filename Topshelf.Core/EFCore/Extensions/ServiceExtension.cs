using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Topshelf.Core
{
    public static class ServiceExtension
    {
        public static object GetDbContext(this IServiceProvider provider, string dbContextTagName, Type serviceType)
        {
            if (provider == null) throw new ArgumentNullException(nameof(provider));
            var implService = provider.GetRequiredService(serviceType);
            var option = provider.GetServices<DbContextOption>().FirstOrDefault(m => m.TagName == dbContextTagName);
            var context = Activator.CreateInstance(implService.GetType(), option);
            return context;
        }
    }
}
