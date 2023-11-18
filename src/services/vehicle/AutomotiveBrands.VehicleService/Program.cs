var builder = WebApplication.CreateBuilder(args);

builder.Services.AddLibraries();
builder.Services.AddMediatR();
builder.Services.AddPostgreSqlServerDbContext<VehicleDbContext>(nameof(VehicleDbContext), false);
builder.Services.AddRepositories();

var app = builder.Build();
await app.MigrateDatabaseAsync<VehicleDbContext>();

app.UseApplicationMiddlewares();
app.UseApplicationLifetimes();
await VehicleDbContextSeed.SeedAsync(builder);

app.Use(async (a, b) =>
{
    try
    {
        await b();
    }
    catch (Exception ex)
    {
        Log.Error(ex, "");
    }
});

await app.StartProjectAsync();