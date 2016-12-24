﻿using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Volo.Abp.Identity.EntityFrameworkCore
{
    [DependsOn(typeof(AbpIdentityModule), typeof(AbpEntityFrameworkCoreModule))]
    public class AbpIdentityEntityFrameworkCoreModule : AbpModule
    {
        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddAbpDbContext<IdentityDbContext>(options =>
            {
                options.AddDefaultRepositories(true);
                options.AddCustomRepository<IdentityUser, EfCoreIdentityUserRepository>();
            });

            services.AddAssemblyOf<AbpIdentityEntityFrameworkCoreModule>();
        }
    }
}