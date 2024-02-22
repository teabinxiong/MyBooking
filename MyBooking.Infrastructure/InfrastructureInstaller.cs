using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyBooking.Application.Abstractions.Clock;
using MyBooking.Application.Abstractions.Email;
using MyBooking.Infrastructure.Clock;
using MyBooking.Infrastructure.Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBooking.Infrastructure
{
    public static class InfrastructureInstaller
    {
        public static IServiceCollection InstallInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {

            services.AddTransient<IDateTimeProvider, DateTimeProvider>();
            services.AddTransient<IEmailService, EmailService>();


            return services;
        }
    }
}
