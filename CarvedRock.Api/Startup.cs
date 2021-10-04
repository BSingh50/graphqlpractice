using CarvedRock.Api.Data;
using CarvedRock.Api.GraphQL;
using CarvedRock.Api.GraphQL.Authorisation;
using CarvedRock.Api.GraphQL.Messaging;
using CarvedRock.Api.Repositories;
// using GraphQL;
// using GraphQL.SystemTextJson;
//using GraphQL.NewtonsoftJson;
using GraphQL.Server;
using GraphQL.Server.Transports.AspNetCore;
// using GraphQL.Types;
// using GraphQL.DataLoader;
using GraphQL.Server.Ui.Playground;
// using GraphQL.SystemTextJson;
// using GraphQL.Server.Transports.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CarvedRock.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<CarvedRockDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("CarvedRock"));
            });

            services.AddScoped<ProductRepository>();
            services.AddScoped<ProductReviewRepository>();
            services.AddScoped<CarvedRockSchema>();
            services.AddSingleton<ReviewMessageService>();
            services.AddGraphQL(options =>
                {
                    options.EnableMetrics = true;
                })
                .AddGraphTypes(ServiceLifetime.Scoped)
                .AddUserContextBuilder(httpContext => new GraphQLUserContext {User = httpContext.User})
                .AddSystemTextJson()
                .AddDataLoader()
                .AddWebSockets();
                //.AddErrorInfoProvider(opt => opt.ExposeExceptionStackTrace = true);
            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,
            CarvedRockDbContext dbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                if (dbContext.Database.IsRelational())
                {
                    dbContext.Database.Migrate();
                }
            }
            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());            app.UseWebSockets();
            app.UseWebSockets();
            app.UseGraphQLWebSockets<CarvedRockSchema>("/graphql");
            app.UseGraphQL<CarvedRockSchema>();
            app.UseGraphQLPlayground(new PlaygroundOptions());

            // app.UseRouting();
            //
            // app.UseEndpoints(endpoints =>
            // {
            //     endpoints.MapGet("/", async context => { await context.Response.WriteAsync("Hello World!"); });
            // });
        }
    }
}