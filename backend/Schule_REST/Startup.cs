using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Converters;
using Schule_REST.Database;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

namespace Schule_REST
{
    public class Startup
    {
        public Startup(IWebHostEnvironment env)
        {            
            var builder = new ConfigurationBuilder()
              .SetBasePath(env.ContentRootPath)
              .AddJsonFile("config/settings.json", optional: true, reloadOnChange: true)
              .AddEnvironmentVariables();

            Configuration = builder.Build();
        }


        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            #region Standard Services

            services.AddCors();
            services.AddControllers()
                  .AddNewtonsoftJson(options =>
                      options.SerializerSettings.Converters.Add(new StringEnumConverter()))
                  .AddNewtonsoftJson(x =>
                      x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                  );
            services.Configure<RouteOptions>(options => options.LowercaseUrls = true);
            services.Configure<KestrelServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });

            #endregion

            #region Selfmade Services

            #endregion

            #region DataSources

            string connection = @"server=" + @Configuration["local_db:host"]
                    + ";port=3306"
                    + ";database=" + @Configuration["local_db:database"]
                    + ";userid=" + @Configuration["local_db:user"]
                    + ";password=" + @Configuration["local_db:password"] + ";";

            services.AddDbContext<DatabaseContext>(options => options.UseMySql(connection,
                ServerVersion.AutoDetect(connection))
            );

            #endregion

            #region Health

            services.AddHealthChecks()
               .AddDbContextCheck<DatabaseContext>();

            #endregion

            #region Swagger

            services.AddSwaggerGenNewtonsoftSupport();
            services.AddSwaggerGen(c =>
            {
                c.CustomOperationIds(apiDesc =>
                {
                    return apiDesc.TryGetMethodInfo(out MethodInfo methodInfo) ? methodInfo.Name : null;
                });

                c.UseInlineDefinitionsForEnums();

                c.SwaggerDoc($"{Assembly.GetExecutingAssembly().GetName().Version.Major}.{Assembly.GetExecutingAssembly().GetName().Version.Minor}.{Assembly.GetExecutingAssembly().GetName().Version.Build}", new OpenApiInfo
                {
                    Title = Assembly.GetExecutingAssembly().GetName().Name.ToString().Replace("_", " "),
                    Version = $"{Assembly.GetExecutingAssembly().GetName().Version.Major}.{Assembly.GetExecutingAssembly().GetName().Version.Minor}.{Assembly.GetExecutingAssembly().GetName().Version.Build}"
                });

                var xmlFile = Assembly.GetExecutingAssembly().GetName().Name.ToString() + ".xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app.UseRouting();
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .WithExposedHeaders("Content-Disposition")); 
            app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                    endpoints.MapHealthChecks("/hc");
                });
            app.UseHealthChecks("/hc");

            string text = Configuration["swagger:endpoint"].ToString();
            if (Assembly.GetExecutingAssembly().GetName().Version != null)
            {
                text = text.Replace("v1", $"{Assembly.GetExecutingAssembly().GetName().Version.Major}.{Assembly.GetExecutingAssembly().GetName().Version.Minor}.{Assembly.GetExecutingAssembly().GetName().Version.Build}");
            }

            app.UseSwagger().UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(text, Assembly.GetExecutingAssembly().GetName().Name.ToString().Replace("_", " "));
            });
        }
    }

}
