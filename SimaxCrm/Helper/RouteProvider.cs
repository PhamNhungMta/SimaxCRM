using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace SimaxCrm.Helper
{
    public static class RouteProvider
    {
        public static void AdminEndpointMapping(IEndpointRouteBuilder endpoints)
        {
            endpoints.MapAreaControllerRoute(
             name: "Admin",
             areaName: "Admin",
             pattern: "Admin/{controller}/{action=Index}/{id?}");
            endpoints.MapRazorPages();
        }

        public static void MainEndpointMapping(IEndpointRouteBuilder endpoints)
        {
            endpoints.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");
            endpoints.MapControllerRoute(name: "products", pattern: "{controller=Products}/{action=Single}/{id?}/{name?}");
            endpoints.MapControllerRoute(name: "projects", pattern: "{controller=Projects}/{action=Single}/{id?}/{name?}");
            endpoints.MapRazorPages();
        }
    }
}
