using Hospital.Infrastructure;
using Hospital.Infrastructure.Databases;


namespace Hospital.WebApi
{
    public partial class Program
    {
        public async static Task Main(string[] args)
        {
            var config = BuildConfiguration();

            var appBuilder = WebApplication.CreateBuilder(args);

            var services = ConfigureServices(appBuilder.Services, config);

            var app = ConfigureApplication(appBuilder.Build());

            await app.RunAsync();
        }

        internal static IConfigurationRoot BuildConfiguration()
        {
            var cBuilder = new ConfigurationBuilder();
            cBuilder.SetBasePath(Directory.GetCurrentDirectory());
            cBuilder.AddJsonFile("appsettings.json");
            return cBuilder.Build();
        }

        internal static IServiceCollection ConfigureServices(IServiceCollection services, IConfiguration config)
        {
            services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            //Add Infrastructure services from our extension method
            services.AddInfrastructure(config);

            //Add Services from application`s project extension method
            services.AddApplicationServices(config);

            return services;
        }

        internal static WebApplication ConfigureApplication(WebApplication app)
        {
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            //app.UseAuthorization();

            app.MapControllers();

            InitializeDatabase(app);

            return app;
        }

        internal static void InitializeDatabase(WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var db = services.GetRequiredService<HospitalContext>();
                db.Initialize(app.Environment.IsDevelopment());
            }
        }
    }
}
