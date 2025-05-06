using BoekenAPI2025.Domain.Data;
using Microsoft.Extensions.DependencyInjection;

namespace BoekenAPI2025.Domain
{
    public static class ServicesConfiguration
    {
        public static void RegisterServices(IServiceCollection services, string connectionString)
        {
            services.AddSqlite<Boeken2025Context>(connectionString);
        }
    }
}
