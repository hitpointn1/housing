using Microsoft.Extensions.DependencyInjection;

namespace Housing.Data
{
    public static class ServiceRegister
    {
        public static IServiceCollection AddDataLayer(this IServiceCollection services, string connectionString)
        {
            services.AddNpgsql<HousingContext>(connectionString);

            return services;
        }
    }
}
