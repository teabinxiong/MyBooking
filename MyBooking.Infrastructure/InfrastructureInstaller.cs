using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyBooking.Application.Abstractions.Clock;
using MyBooking.Application.Abstractions.Data;
using MyBooking.Application.Abstractions.Email;
using MyBooking.Domain.Abstractions;
using MyBooking.Domain.Apartments;
using MyBooking.Domain.Bookings;
using MyBooking.Domain.Users;
using MyBooking.Infrastructure.Clock;
using MyBooking.Infrastructure.Data;
using MyBooking.Infrastructure.Email;
using MyBooking.Infrastructure.Repositories;
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

            var conString = configuration.GetConnectionString("Database") ??
                throw new ArgumentNullException(nameof(configuration));

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseNpgsql(conString).UseSnakeCaseNamingConvention();
            });

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IApartmentRepository, ApartmentRepository>();
            services.AddScoped<IBookingRepository, BookingRepository>();

            services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<ApplicationDbContext>());


            services.AddSingleton<ISqlConnectionFactory>(_ => new SqlConnectionFactory(conString));

            SqlMapper.AddTypeHandler(new DateOnlyTypeHandler());

            return services;
        }
    }
}
