using GameStore.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.Installers
{
    public class DbInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configration)
        {
            services.AddDbContext<GamesContext>(opt => opt.UseSqlServer(configration.GetConnectionString("GameConnection")));
            //services.AddDefaultIdentity<IdentityUser>();
            services.AddIdentityCore<IdentityUser>()
                .AddEntityFrameworkStores<GamesContext>();
            services.AddOptions();
            

        }
    }
}
