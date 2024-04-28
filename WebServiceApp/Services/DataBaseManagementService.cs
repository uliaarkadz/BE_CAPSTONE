using Microsoft.EntityFrameworkCore;
using WebServiceApp.DbContext;

namespace WebServiceApp.Services;

public class DataBaseManagementService
{
    public static void MigrationInitialisation(IApplicationBuilder app)
    {
        using (var serviceScope = app.ApplicationServices.CreateScope())
        {
            serviceScope.ServiceProvider.GetService<StoreContext>().Database.Migrate();
        }
    }
}