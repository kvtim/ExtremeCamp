using Users.Data;
using Microsoft.EntityFrameworkCore;

namespace Users.Api.Extensions
{
    public static class MigrationsExtension
    {
        public static void MigrateIfDbNotCreated(this WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                if (!scope.ServiceProvider.
                    GetRequiredService<ApplicationDbContext>().
                    Database.CanConnect())
                {
                    scope.ServiceProvider.GetRequiredService<ApplicationDbContext>().Database.Migrate();
                }
            }
        }
    }
}
