using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using Volo.Abp.Uow;
using Xunit;

namespace LightweightAbp.Domain.Test
{
    public class TestBase
    {
        private readonly IConfiguration configuration;
        protected readonly IServiceProvider _serviceProvider;
        public TestBase()
        {
            var builder = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    ;
            configuration = builder.Build();
            var services = new ServiceCollection();
            services.AddApplication<LightweightAbpDomainTestModule>();

            _serviceProvider = services.BuildServiceProvider();
        }



        protected virtual T GetRequiredService<T>()
        {
            return _serviceProvider.GetRequiredService<T>();
        }

        protected virtual Task WithUnitOfWorkAsync(Func<Task> func)
        {
            return WithUnitOfWorkAsync(new AbpUnitOfWorkOptions(), func);
        }


        protected virtual async Task WithUnitOfWorkAsync(AbpUnitOfWorkOptions options, Func<Task> action)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var uowManager = scope.ServiceProvider.GetRequiredService<IUnitOfWorkManager>();

                using (var uow = uowManager.Begin(options))
                {
                    await action();
                    await uow.CompleteAsync();
                }
            }
        }
    }
}
