var builder = WebApplication.CreateBuilder(args);

builder.AddHostExtensions();
builder.Services.AddLibraries();
builder.Services.AddMediatR();
builder.Services.AddPostgreSqlServerDbContext<UserDbContext>(nameof(UserDbContext), false);
builder.Services.AddRepositories();


var app = builder.Build();
await app.MigrateDatabaseAsync<UserDbContext>();

app.UseApplicationMiddlewares();

await UserDbContextSeed.SeedAsync(builder);

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