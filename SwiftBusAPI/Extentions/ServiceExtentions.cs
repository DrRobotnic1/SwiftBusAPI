using Domain.Data;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;


namespace SwiftBusAPI.Extentions
{
    public static class ServiceExtentions
    {
        public static void AddAppDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<SwiftBusDataContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
        }
    }
}
