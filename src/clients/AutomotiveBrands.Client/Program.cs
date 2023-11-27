var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddHostingSetting();
builder.Services.AddBuiltInServices();
builder.Services.AddHelpers();
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseMiddleware<AntiXssMiddleware>();

if (app.Environment.IsProduction())
{
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute(Routes.ErrorPage, Routes.ErrorPageQueryString);
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.MapRazorPages();
app.UseCustomEndpoint();

await app.RunAsync();