using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using ChhotaNivesh.Business;
using ChhotaNivesh.DBCore;
using ChhotaNivesh.Services;
using ChhotaNiveshToolApp.Helpers;
using ChhotaNiveshToolApp.Services;
using Microsoft.EntityFrameworkCore;

namespace ChhotaNiveshToolApp
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

            services.AddDbContext<DBContext>(options => options.UseSqlServer(
              Configuration.GetConnectionString("DefaultConnection")));

            services.AddDbContext<DBContextFD>(options => options.UseSqlServer(
               Configuration.GetConnectionString("DefaultConnectionChhotaNiveshFD")));


            // configure strongly typed settings object
            services.Configure<ChhotaNivesh.Common.Models.AppSettings>(Configuration.GetSection("AppSettings"));

            // Resolve dependencies
         
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddTransient<ICompanyService, CompanyService>();
            services.AddTransient<IUsersService, UsersService>();
            services.AddTransient<IProductService, ProductService>();


            // configure DI for application services
            services.AddScoped<IAuthenticationService, AuthenticationService>();

            services.AddTransient<IUsersManager, UsersManager>();

            services.AddTransient<ITransactionLogManager, TransactionLogManager>();
            services.AddTransient<ITransactionLogService, TransactionLogService>();

      

            // Register the Swagger generator, defining 1 or more Swagger documents
            //services.AddSwaggerGen(
            //    options =>

            //    options.OperationFilter<SecurityRequirementsOperationFilter>()    
            //);

            services.AddSwaggerGen(swagger =>
            {
                //This is to generate the Default UI of Swagger Documentation  
                swagger.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Price Compare Tool API",
                    Description = "Price Compare Tool API"
                });
                // To Enable authorization using Swagger (JWT)  
                swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
                });
                swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}

                    }
                });
            });

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder => builder
                                .AllowAnyOrigin()
                                .AllowAnyMethod()
                                .AllowAnyHeader()
                                .SetIsOriginAllowedToAllowWildcardSubdomains()
                );
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,
            ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            loggerFactory.AddFile("Logs/chhotaniveshapi-{Date}.txt");

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Price Compare Tool API");
            });

            app.UseHttpsRedirection();

            app.UseCors();

            app.Use((context, next) =>
            {
                context.Items["__CorsMiddlewareInvoked"] = true;
                return next();
            });

            app.UseRouting();

            app.UseAuthorization();

            // custom jwt auth middleware
            app.UseMiddleware<JwtMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });            
        }
    }
}
