using Housing.Services.Queries.Bills;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Housing.Services
{
    public static class ServiceRegister
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddScoped<PaymentRetrievalTemplate>();

            return services;
        }
    }
}
