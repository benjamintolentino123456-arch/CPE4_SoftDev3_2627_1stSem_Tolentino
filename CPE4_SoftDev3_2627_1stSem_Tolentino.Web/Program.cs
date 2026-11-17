using CPE4_SoftDev3_2627_1stSem_Tolentino.Shared.Services;
using CPE4_SoftDev3_2627_1stSem_Tolentino.Web.Components;
using CPE4_SoftDev3_2627_1stSem_Tolentino.Web.Data.Entities;
using CPE4_SoftDev3_2627_1stSem_Tolentino.Web.Services;
using CPE4_SoftDev3_2627_1stSem_Tolentino.Web.Data; 
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Runtime.InteropServices;
using CPE4_SoftDev3_2627_1stSem_Tolentino.Web;
using Microsoft.AspNetCore.Components.Server;
using Microsoft.AspNetCore.Components.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Add device-specific services used by the CPE4_SoftDev3_2627_1stSem_Tolentino.Shared project
builder.Services.AddSingleton<IFormFactor, FormFactor>();

builder.Services.AddDbContextFactory<DataContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("Default");
    options.UseSqlServer(connectionString);
});

builder.Services.AddTransient<IPasswordHasher<User>, PasswordHasher<User>>();

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IEventService, EventService>();


builder.Services.AddAuthentication(WebConstants.WebAuthenticationScheme)
    .AddCookie(WebConstants.WebAuthenticationScheme, options =>
    {
        options.Cookie.Name = WebConstants.WebAuthenticationScheme;
        options.LoginPath = "/login";
        options.LogoutPath = "/logout";
        options.Cookie.HttpOnly = true;
        options.SlidingExpiration = true;
        options.ExpireTimeSpan = TimeSpan.FromDays(1);
        options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
    });
builder.Services.AddAuthorization();
builder.Services.AddHttpContextAccessor();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<AuthenticationStateProvider, WebAuthStateProvider>();

var app = builder.Build();

AutoMigrateDatabase(app.Services);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

// Add Permissions-Policy header to allow unload event
app.Use(async (context, next) =>
{
    context.Response.Headers.Append("Permissions-Policy", "unload=*");
    await next();
});

app.UseAuthentication().UseAuthorization();

app.UseAntiforgery();

app.MapStaticAssets();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddAdditionalAssemblies(
        typeof(CPE4_SoftDev3_2627_1stSem_Tolentino.Shared._Imports).Assembly);

app.Run();

static void AutoMigrateDatabase(IServiceProvider serviceProvider)
{
    using var scope = serviceProvider.CreateScope();
    var contextFactory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<DataContext>>();
    using var context = contextFactory.CreateDbContext();

    try
    {
        // Create database if it doesn't exist, but don't delete existing data
        context.Database.EnsureCreated();

        // Apply pending migrations
        if (context.Database.GetPendingMigrations().Any())
            context.Database.Migrate();
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Database migration error: {ex.Message}");
    }
}

