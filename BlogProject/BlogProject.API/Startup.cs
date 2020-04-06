using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogProject.API.Configuration;
using BlogProject.API.Configuration.Extentions;
using BlogProject.Core.Services;
using BlogProject.Core.Services.Interfaces;
using BlogProject.DataLayer.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace BlogProject.API
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

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            services.AddControllers()
                .AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.StringEscapeHandling = StringEscapeHandling.EscapeNonAscii;
            });


            //services.AddDbContext<BlogProjectContext>(option =>
            //option.UseSqlServer(Configuration.GetConnectionString("BlogProjectConnection"))
            //);
            services.AddDbContext<BlogProjectContext>(option =>
                       option.UseSqlServer("Data Source=.;Initial Catalog=BlogProject_DB;Integrated Security=True")
                       );


            //JWT
            // configure strongly typed settings objects
            // var appSettingsSection = Configuration.GetSection("AppSettings");
            //  services.Configure<AppSettings>(appSettingsSection);

            // configure jwt authentication
            // var appSettings = appSettingsSection.Get<AppSettings>();
             var appSettings = new AppSettings() { Secret = "This is the secret key and its very important" };
            services.AddOurAuthentication(appSettings);
            services.AddOurSwaager();


            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IPostRepository, PostRepository>();
            services.AddTransient<IAuthRepository, AuthRepository>();

            services.AddCors(options =>
            {
                options.AddPolicy("EnableCors", builder =>
                {
                    builder.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .Build();
                });


            });





        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication(); // this one first
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


            app.UseCors("EnableCors");

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            });


        }
    }
}
