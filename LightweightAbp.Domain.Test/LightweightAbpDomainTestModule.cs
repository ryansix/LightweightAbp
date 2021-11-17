using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace LightweightAbp.Domain.Test
{
    [DependsOn(typeof(LightweightAbpCoreModule))]
   public class LightweightAbpDomainTestModule:AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpDbContextOptions>(options =>
            {
                options.UseSqlite();
            });
        }
    }
}
