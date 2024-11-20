using Mapster;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;
using Student.Application.Services;
using Student.Domain.Interfaces;
using System.Reflection;

namespace Student.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationDependencies(this IServiceCollection services)
        {
            services.AddMapsterServices();

            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IFamilyService, FamilyService>();
            services.AddScoped<INationalityService, NationalityService>();
            return services;
        }

        private static IServiceCollection AddMapsterServices(this IServiceCollection services)
        {
            var mappingConfig = TypeAdapterConfig.GlobalSettings;
            mappingConfig.Scan(Assembly.GetExecutingAssembly());
            services.AddSingleton<IMapper>(new Mapper(mappingConfig));
            return services;
        }
    }
}
