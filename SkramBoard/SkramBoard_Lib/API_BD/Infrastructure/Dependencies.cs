using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class Dependencies
{
    public static void ConfigureServices(IConfiguration configuration, IServiceCollection services)
    {
        services.AddDbContext<ScrumBoardRelation>(options => options.UseMySql(
            configuration.GetConnectionString("Default"),
            ServerVersion.AutoDetect(configuration.GetConnectionString("Default"))
        ));
    }
}