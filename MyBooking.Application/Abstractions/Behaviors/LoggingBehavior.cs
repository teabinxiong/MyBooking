using MediatR;
using Microsoft.Extensions.Logging;
using MyBooking.Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace MyBooking.Application.Abstractions.Behaviors
{
    public class LoggingBehavior<TRequest, TResponse>
        : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IBaseCommand
    {

        private readonly ILogger _logger;

        public LoggingBehavior(ILogger logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(
            TRequest request, 
            RequestHandlerDelegate<TResponse> next, 
            CancellationToken cancellationToken)
        {
            var name = request.GetType().Name;

            try
            {
                _logger.LogInformation("Executing Command {Command}", name);

                var result = await next();

                _logger.LogInformation( "Command {Command} processing successfully", name);

                return result;
            } 
            catch(Exception ex)
            {
                _logger.LogError(ex, "Command {Command} processing failed", name);

                throw;
            }
        }
    }
}
