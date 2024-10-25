using Cpm.Api.Application.Interface;
using Cpm.Api.Application.Provider;
using Microsoft.Extensions.DependencyInjection;


namespace Cpm.Api.Application.Extension
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection service)
        {
            service.AddScoped<IClinicService, ClinicService>();
            service.AddScoped<IDoctorService, DoctorService>();
            return service;
        }
    }
}
