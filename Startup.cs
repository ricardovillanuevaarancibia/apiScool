using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiScool.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using Microsoft.IdentityModel.Tokens;
using NSwag;
using NSwag.Generation.Processors.Security;

namespace ApiScool
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


            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
             .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = "https://apiscool20191110023542.azurewebsites.net",
                    ValidAudience = "https://apiscool20191110023542.azurewebsites.net",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:key"]))
                };
            });

            services.AddCors(options =>
            {
                options.AddPolicy("PermitirApiRequest",
                    builder => builder.WithOrigins("http://www.apirequest.io").WithMethods("GET", "POST").AllowAnyHeader());
            });
            services.AddDbContext<ScoolBdContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));


            services.AddMvc(option => option.EnableEndpointRouting = false).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddOpenApiDocument(document =>
            {
                document.Title = "Título del Web API";
                document.Description = "Descripción del Web API.";

                // CONFIGURAMOS LA SEGURIDAD JWT PARA SWAGGER,
                // PERMITE AÑADIR EL TOKEN JWT A LA CABECERA.
                document.AddSecurity("JWT", Enumerable.Empty<string>(),
                    new OpenApiSecurityScheme
                    {
                        Type = OpenApiSecuritySchemeType.ApiKey,
                        Name = "Authorization",
                        In = OpenApiSecurityApiKeyLocation.Header,
                        Description = "Copia y pega el Token en el campo 'Value:' así: Bearer {Token JWT}."
                    }
                );

                document.OperationProcessors.Add(
                    new AspNetCoreOperationSecurityScopeProcessor("JWT"));
            });

            services.Configure<RequestLocalizationOptions>(
                       opts =>
                       {
                           var supportedCultures = new[]
                           {

                        new System.Globalization.CultureInfo("es-PE"),
                           };

                           opts.DefaultRequestCulture = new RequestCulture("es-PE");
                            // Formatting numbers, dates, etc.
                            opts.SupportedCultures = supportedCultures;
                            // UI strings that we have localized.
                            opts.SupportedUICultures = supportedCultures;
                       });

            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseOpenApi();
            app.UseSwaggerUi3();


            app.UseHttpsRedirection();
            app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseMvc();
        }
    }
}
