using HR.LeaveManagement.Application.Contracts.Emails;
using HR.LeaveManagement.Application.Contracts.Logging;
using HR.LeaveManagement.Application.Models;
using HR.LeaveManagement.Infrastructure.EmailService;
using HR.LeaveManagement.Infrastructure.LoggingService;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HR.LeaveManagement.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices (this IServiceCollection services, IConfiguration configuration) 
        {
            var config = configuration.GetSection("EmailSettings");
            services.Configure<EmailSettings>(config);
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddScoped(typeof(IAppLogger<>),typeof(LoggerAdapter<>));
            return services;
        } 
    }
}