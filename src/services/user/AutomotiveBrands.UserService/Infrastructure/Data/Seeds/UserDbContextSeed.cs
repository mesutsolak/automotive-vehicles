namespace AutomotiveBrands.UserService.Infrastructure.Data.Seeds
{
    internal static class UserDbContextSeed
    {
        internal static async Task SeedAsync(WebApplicationBuilder webApplicationBuilder, int? retry = 0)
        {
            if (!webApplicationBuilder.Environment.IsLocalhost())
            {
                await Task.CompletedTask;
                return;
            }

            int retryForAvailability = retry.Value;
            UserDbContext userDbContext = webApplicationBuilder.Services.BuildServiceProvider().GetRequiredService<UserDbContext>();

            try
            {
                bool isConnected = await userDbContext.Database.CanConnectAsync();
                if (!isConnected)
                {
                    await userDbContext.Database.EnsureCreatedAsync();
                    await SeedAsync(webApplicationBuilder, retryForAvailability);
                }

                await userDbContext.Database.MigrateAsync();

                if (!await userDbContext.Preferences.AnyAsync())
                {
                    await userDbContext.Preferences.AddAsync(GetPreConfiguredPreference());
                }

                await userDbContext.SaveChangesAsync();
            }
            catch (Exception exception)
            {
                Console.WriteLine("Migration Error: {0}", exception.Message);

                if (retryForAvailability < 3)
                {
                    retryForAvailability++;
                    Log.Error(exception, "User servis geçici veri eklerken hata oluştu.");

                    Thread.Sleep(2000);
                    await SeedAsync(webApplicationBuilder, retryForAvailability);
                }
            }
        }

        private static Preference GetPreConfiguredPreference()
        {
            return new Preference();
        }
    }
}
