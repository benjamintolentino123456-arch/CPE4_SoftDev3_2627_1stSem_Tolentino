using CPE4_SoftDev3_2627_1stSem_Tolentino.Shared.Services;
using CPE4_SoftDev3_2627_1stSem_Tolentino.Web.Components;
using CPE4_SoftDev3_2627_1stSem_Tolentino.Web.Data.Entities;
using CPE4_SoftDev3_2627_1stSem_Tolentino.Web.Services;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

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

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddAdditionalAssemblies(
        typeof(CPE4_SoftDev3_2627_1stSem_Tolentino.Shared._Imports).Assembly);

app.Run();
