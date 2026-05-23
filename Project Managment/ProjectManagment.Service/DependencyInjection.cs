
using Microsoft.Extensions.DependencyInjection;
using Project_Managment.Application.Services;
using Project_Managment.Service.Interfaces;
using Project_Managment.Service.Services;
using ProjectManagment.Application.Services;


namespace Project_Managment.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependencyInjectionApplication(this IServiceCollection services)
        {

            services.AddScoped<IProjectService, ProjectServices>();
            services.AddScoped<ITaskService, TaskService>();
            services.AddScoped<IAuthService, AuthService>();
            return services;
        }
    }
}
