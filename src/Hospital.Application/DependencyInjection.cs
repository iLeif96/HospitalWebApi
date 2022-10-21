using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Hospital.Application.Interfaces.Services;
using Hospital.Application.Mappers;
using Hospital.Application.Services;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Hospital.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddTransient<IPatientsService, PatientsService>();
            services.AddTransient<IDoctorsService, DoctorsService>();

            services.AddAutoMapper(typeof(HospitalMappingProfile));

            return services;
        }
    }
}
