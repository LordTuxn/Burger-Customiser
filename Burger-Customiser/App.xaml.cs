using Burger_Customiser_DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System.Windows;
using System.IO;

namespace Burger_Customiser {

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application {

        private readonly ServiceProvider serviceProvider;
        private IConfiguration config;
        
        public App() {
            ConfigureConfiguration();
            
            ServiceCollection services = new ServiceCollection();
            ConfigureServices(services);
            serviceProvider = services.BuildServiceProvider();
        }

        public void ConfigureServices(IServiceCollection service) {
            service.AddSingleton<StartWindow>();
            service.Configure<StartWindow>(config.GetSection("Application"));

            service.AddDbContext<ArticleDBContext>(options => {
                string connectionString = config.GetSection("Database").GetSection("ConnectionString").Value;
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            });
        }
        
        public void ConfigureConfiguration() {
            IConfigurationBuilder configBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            config = configBuilder.Build();
        }
    }
}