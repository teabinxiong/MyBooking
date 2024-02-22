using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using MyBooking.Application.Abstractions.Behaviors;
using MyBooking.Domain.Bookings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MyBooking.Application
{
    public static class ApplicationInstaller
    {
        public static IServiceCollection InstallApplication(this IServiceCollection services)
        {
            services.AddMediatR(configuration =>
            {
                configuration.RegisterServicesFromAssembly(typeof(ApplicationInstaller).Assembly);

                configuration.AddOpenBehavior(typeof(LoggingBehavior<,>));

                configuration.AddOpenBehavior(typeof(ValidationBehavior<,>));
            });

            services.AddValidatorsFromAssembly(typeof(ApplicationInstaller).Assembly);

            services.AddTransient<PricingService>();

            return services;
        }
    }
}
