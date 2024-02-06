﻿using Microsoft.Extensions.DependencyInjection;
using MyBooking.Domain.Bookings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MyBooking.Application
{
    public static class Installer
    {
        public static IServiceCollection InstallApplication(this IServiceCollection services)
        {
            services.AddMediatR(configuration =>
            {
                configuration.RegisterServicesFromAssembly(typeof(Installer).Assembly);
            });

            services.AddTransient<PricingService>();

            return services;
        }
    }
}