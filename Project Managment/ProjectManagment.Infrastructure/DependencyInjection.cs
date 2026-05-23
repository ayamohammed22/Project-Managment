using Microsoft.Extensions.DependencyInjection;
using Project_Managment.Infrastructure.Authentications;
using Project_Managment.Infrastructure.Interfaces;
using Project_Managment.Infrastructure.Repositiories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Managment.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDePendancyInjectionInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IJwtProvider, JwtProvider>();
            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
            return services;
        }
    }
}
