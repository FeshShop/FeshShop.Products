namespace FeshShop.Products
{
    using FeshShop.Common;
    using FeshShop.Common.Mediator;
    using FeshShop.Common.Mongo;
    using FeshShop.Common.Mongo.Contracts;
    using FeshShop.Common.Mvc;
    using FeshShop.Products.Domain;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using System.Reflection;

    public class Startup
    {
        private const string CorsPolicy = nameof(CorsPolicy);
        private static readonly string[] Headers = new[] { "X-Operation", "X-Resource", "X-Total-Count" };

        public Startup(IConfiguration configuration) => this.Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddInitializers(typeof(IMongoDbInitializer))
                .AddMongoDatabase(this.Configuration)
                .AddScoped(typeof(IMongoRepository<Product>), typeof(MongoRepository<Product>))
                .AddServices(Assembly.GetExecutingAssembly())
                .AddMediator()
                .AddCors(options =>
                {
                    options.AddPolicy(CorsPolicy, cors =>
                            cors.AllowAnyOrigin()
                                .AllowAnyMethod()
                                .AllowAnyHeader()
                                .WithExposedHeaders(Headers));
                })                
                .AddControllers()
                .AddNewtonsoftJson();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IStartupInitializer startupInitializer)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app
                .UseCors(CorsPolicy)
                .UseHttpsRedirection()
                .UseRouting()
                .UseAuthorization()
                .UseEndpoints(endpoints => endpoints.MapControllers());

            startupInitializer.InitializeAsync();
        }
    }
}
