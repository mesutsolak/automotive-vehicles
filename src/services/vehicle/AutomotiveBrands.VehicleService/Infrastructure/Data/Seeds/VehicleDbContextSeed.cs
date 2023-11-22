namespace AutomotiveBrands.VehicleService.Infrastructure.Data.Seeds
{
    internal static class VehicleDbContextSeed
    {
        internal static async Task SeedAsync(WebApplicationBuilder webApplicationBuilder, int? retry = 0)
        {
            if (!webApplicationBuilder.Environment.IsLocalhost())
            {
                await Task.CompletedTask;
                return;
            }

            int retryForAvailability = retry.Value;
            VehicleDbContext vehicleDbContext = webApplicationBuilder.Services.BuildServiceProvider().GetRequiredService<VehicleDbContext>();

            try
            {
                bool isConnected = await vehicleDbContext.Database.CanConnectAsync();
                if (!isConnected)
                {
                    await vehicleDbContext.Database.EnsureCreatedAsync();
                    await SeedAsync(webApplicationBuilder, retryForAvailability);
                }

                await vehicleDbContext.Database.MigrateAsync();

                if (!await vehicleDbContext.Vehicles.AnyAsync())
                {
                    await vehicleDbContext.Vehicles.AddAsync(GetPreConfiguredVehicle());
                }

                if (!await vehicleDbContext.VehicleDetails.AnyAsync())
                {
                    await vehicleDbContext.VehicleDetails.AddAsync(GetPreConfiguredVehicleDetail());
                }

                await vehicleDbContext.SaveChangesAsync();
            }
            catch (Exception exception)
            {
                Console.WriteLine("Migration Error: {0}", exception.Message);

                if (retryForAvailability < 3)
                {
                    retryForAvailability++;
                    Log.Error(exception, "Araç servisine geçici veri eklerken hata oluştu.");

                    Thread.Sleep(2000);
                    await SeedAsync(webApplicationBuilder, retryForAvailability);
                }
            }
        }

        private static Vehicle GetPreConfiguredVehicle()
        {
            return new Vehicle();
        }

        private static VehicleDetail GetPreConfiguredVehicleDetail()
        {
            return new VehicleDetail();
        }
    }
}
