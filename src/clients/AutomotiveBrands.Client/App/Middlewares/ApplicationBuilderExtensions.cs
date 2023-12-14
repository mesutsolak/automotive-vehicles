namespace AutomotiveBrands.Client.App.Middlewares
{
    internal static class ApplicationBuilderExtensions
    {
        internal static void UseCustomEndpoint(this IApplicationBuilder app)
        {
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=List}/{brand=70}");
            });
        }
    }
}
