using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using RocloWebApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.Owin;
using Owin;
using Umbraco.Core.Services;


namespace RocloWebApp
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

            services.AddScoped<IAdmin, IAdminService>();
            services.AddScoped<IBac, IBacsService>();
            services.AddScoped<IClient, IClientService>();
            services.AddScoped<ICollecteur, ICollecteurService>();
            services.AddScoped<ICommande, ICommandeService>();
            services.AddScoped<INotification, Services.INotificationService>();
            services.AddScoped<IProduit, IProduitService>();
            services.AddScoped<IRelation, Services.IRelationService>();
            services.AddScoped<ITypeRelation, ITypeRelationService>();
            services.AddScoped<IConnexion, IConnexionService>();

            services.AddControllersWithViews();
            services.AddControllers();
            services.AddSignalR();
            services.AddSignalRCore();


           /* var key = "This is my test key";
            services.AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                }).AddJwtBearer(x =>
                    {
                        x.RequireHttpsMetadata = false;
                        x.SaveToken = true;
                        x.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuerSigningKey = true,
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
                            ValidateIssuer = false,
                            ValidateAudience = false
                        };
                    });
            services.AddSingleton<IConnexionService>(new IConnexionService(key));

           services.AddSwaggerGen();*/

           // services.AddDbContext<rocloapplication>(options =>
                  //  options.UseSqlServer(Configuration.GetConnectionString("rocloapplication")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
