using API_Assignment_3.Models;
using API_Assignment_3.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;

namespace API_Assignment_3
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

            services.AddControllers();
            // Add AutoMapper
            services.AddAutoMapper(typeof(Startup));
            // Add connection from appsettings.json // Set to production to work with Azure (ConnectionString has been removed from appsettings and added to Azure)
            services.AddDbContext<MediaDbContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("Production")));
            // Add service connection to MovieController 
            services.AddScoped(typeof(MovieService));
            // Add service connection to FranchiseController 
            services.AddScoped(typeof(FranchiseService));
            // Add swagger doc
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "API Assignment 3",
                    Version = "v1",
                    Description = "API Assignment 3 at NorOff",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Mattis Langheim",
                        Email = "mattis@noneofurbiz.com",
                        Url = new Uri("https://github.com/langheim/"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Use under MIT",
                        Url = new Uri("https://opensource.org/licenses/MIT"),
                    }

                });
                // Set the comments path for the Swagger
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);

            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API_Assignment_3 v1"));
            }
            // Added swagger so it works in productive API
            

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
