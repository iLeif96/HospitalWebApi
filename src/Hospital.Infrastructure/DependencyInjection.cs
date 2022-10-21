using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Hospital.Application.Interfaces.Repositories;
using Hospital.Infrastructure.Databases;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Hospital.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            string dbConnectionString = config.GetConnectionString("SqlLocalServer");
            services.AddDbContext<HospitalContext>(options => options.UseSqlServer(dbConnectionString));

            services.AddTransient<IUnitOfWork, UnitOfWorkEF>();

            return services;
        }
    }
}
