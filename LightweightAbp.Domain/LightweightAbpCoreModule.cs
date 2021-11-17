using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application;
using Volo.Abp.Autofac;
using Volo.Abp.Caching;
using Volo.Abp.Domain;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.MySQL;
using Volo.Abp.EntityFrameworkCore.Sqlite;
using Volo.Abp.Modularity;

namespace LightweightAbp
{
    [DependsOn(
         typeof(AbpAutofacModule), 
         typeof(AbpDddApplicationModule),
         typeof(AbpDddDomainModule),
         typeof(AbpEntityFrameworkCoreSqliteModule),
        typeof(AbpEntityFrameworkCoreMySQLModule),
         typeof(AbpCachingModule))]
    public class LightweightAbpCoreModule: AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<LightweightAbpDbContext>(options =>
            {
                options.AddDefaultRepositories(includeAllEntities: true);
            });

            Configure<AbpDbContextOptions>(options =>
            {
                //options.UseSqlite();
                options.UseMySQL();
            });
        }
    }
}
