using Cpm.Api.Domain.Interface;
using Cpm.Api.Inftrastructure.Provider;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cpm.Api.Inftrastructure.Extension
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddInfrastrucureService(this IServiceCollection services)
        {
            services.AddScoped<IClinicRepository, ClinicRepository>();
            services.AddScoped<IDoctorRepository, DoctorRepository>();
            services.AddScoped<IloginRepository, LoginRepository>();
            services.AddScoped<ISkillRepository, SkillRepository>();
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<IPatientDiagnosisRepository, PatientDiagnosisRepository>();
            return services;
        }
    }
}
