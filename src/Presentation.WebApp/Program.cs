using System;
using Application.IServicios;
using Application.Servicios;
using Domain.IRepositorios;
using Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<IdentityDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddScoped(connectionString => builder.Configuration.GetConnectionString("DefaultConnection"));

builder.Services.AddTransient<IFileConvertService, FileConverterService>();
builder.Services.AddTransient<IServicioCitas, ServicioCita>();
builder.Services.AddTransient<IServicioDoctor, ServicioDoctor>();
builder.Services.AddTransient<IServicioPaciente, ServicioPaciente>();
builder.Services.AddTransient<IServicioCatalogos, ServicioCatalogos>();
builder.Services.AddTransient<IServicioUsuarios, ServicioUsuarios>();
builder.Services.AddTransient<IServicioProducto, ServicioProducto>();
builder.Services.AddTransient<IServicioReporte, ServicioReporte>();

var config = builder.Configuration.GetSection("Smtp");
builder.Services.AddTransient<IServicioSmtpCorreo>(x =>
new ServicioSmtpCorreo(config["Displayname"], config["Address"], config["Host"], int.Parse(config["Port"]), config["Username"], config["Password"]));

builder.Services.AddTransient<IRepositorioDoctores, RepositorioDoctores>();
builder.Services.AddTransient<IRepositorioCitas, RepositorioCitas>();
builder.Services.AddTransient<IRepositorioPacientes, RepositorioPacientes>();
builder.Services.AddTransient<IRepositorioCatalogos, RepositorioCatalogos>();
builder.Services.AddTransient<IRepositorioUsuarios, RepositorioUsuarios>();
builder.Services.AddTransient<IRepositorioProductos, RepositorioProductos>();


builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(10);
});

builder.Services.ConfigureApplicationCookie(options =>
{
    // Cookie settings
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(30);

    options.LoginPath = "/Identity/Account/Login";
    options.AccessDeniedPath = "/Identity/Account/AccessDenied";
    options.SlidingExpiration = true;
});


builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseSession();


app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Usuarios}/{action=Index}");
    endpoints.MapRazorPages();
});

Rotativa.AspNetCore.RotativaConfiguration.Setup(app.Environment.WebRootPath, "..\\Rotativa\\Windows\\");

app.Run();
