using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Application.IServicios;
using Application.Servicios;
using Domain.IRepositorios;
using Infrastructure;

namespace Presentation.WebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<IdentityDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddDatabaseDeveloperPageExceptionFilter();
            services.AddScoped(connectionString => Configuration.GetConnectionString("DefaultConnection"));

            services.AddTransient<IFileConvertService, FileConverterService>();
            services.AddTransient<IServicioCitas, ServicioCita>();
            services.AddTransient<IServicioDoctor, ServicioDoctor>();
            services.AddTransient<IServicioPaciente, ServicioPaciente>();
            services.AddTransient<IServicioCatalogos, ServicioCatalogos>();
            services.AddTransient<IServicioUsuarios, ServicioUsuarios>();
            services.AddTransient<IServicioProducto, ServicioProducto>();
            services.AddTransient<IServicioReporte, ServicioReporte>();

            var config = Configuration.GetSection("Smtp");
            services.AddTransient<IServicioSmtpCorreo>(x =>   new ServicioSmtpCorreo(config["Displayname"], config["Address"], config["Host"], int.Parse(config["Port"]), config["Username"], config["Password"]));

            services.AddTransient<IRepositorioDoctores, RepositorioDoctores>();
            services.AddTransient<IRepositorioCitas, RepositorioCitas>();
            services.AddTransient<IRepositorioPacientes, RepositorioPacientes>();
            services.AddTransient<IRepositorioCatalogos, RepositorioCatalogos>();
            services.AddTransient<IRepositorioUsuarios, RepositorioUsuarios>();
            services.AddTransient<IRepositorioProductos, RepositorioProductos>();
            

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(10);
            });

            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(30);

                options.LoginPath = "/Identity/Account/Login";
                options.AccessDeniedPath = "/Identity/Account/AccessDenied";
                options.SlidingExpiration = true;
            });


            services.AddControllersWithViews();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
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
                    pattern: "{controller=Home}/{action=Index}");
                endpoints.MapRazorPages();
            });

            Rotativa.AspNetCore.RotativaConfiguration.Setup(env.WebRootPath, "..\\Rotativa\\Windows\\");
        }
    }
}
