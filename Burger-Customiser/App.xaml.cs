using Burger_Customiser.Navigation.Pages.ArticleOption;
using Burger_Customiser.Navigation.Pages.Catalogue;
using Burger_Customiser.Navigation.Pages.OrderOption;
using Burger_Customiser.Navigation.Pages.Start;
using Burger_Customiser_DAL;
using Burger_Customiser_DAL.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Windows;

namespace Burger_Customiser {

    public partial class App : Application {
        private readonly IHost host;
        private IConfiguration config;

        public App() {
            host = new HostBuilder()
                .ConfigureAppConfiguration((context, configurationBuilder) => {
                    configurationBuilder.SetBasePath(context.HostingEnvironment.ContentRootPath);
                    configurationBuilder.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                    config = configurationBuilder.Build();
                })
                .ConfigureServices(services => {
                    // Inject Database
                    string connectionString =
                        $@"server={config["Data:Server"]}; " +
                        $@"port={config["Data:Port"]}; " +
                        $@"database={config["Data:Database"]}; " +
                        $@"user={config["Data:Username"]}; " +
                        $@"password={config["Data:Password"]}; " +
                        "Persist Security Info=False; Connect Timeout=300;";
                    services.AddDbContextPool<ApplicationDBContext>(options =>
                        options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

                    services.AddScoped<CategoryDAL>();
                    services.AddScoped<ArticleDAL>();

                    services.AddScoped<MainWindowVM>();

                    services.AddScoped<StartPageVM>();
                    services.AddScoped<OrderOptionPageVM>();
                    services.AddScoped<ArticleOptionPageVM>();
                    services.AddScoped<CataloguePageVM>();

                    services.AddScoped<MainWindow>();
                })
                .ConfigureLogging(logging => {
                    logging.AddConfiguration(config.GetSection("Logging"));
                    logging.AddDebug();
                })
                .Build();
        }

        private async void Application_Startup(object sender, StartupEventArgs args) {
            await host.StartAsync();

            host.Services.GetService<MainWindow>().Show();
        }

        private async void Application_Exit(object sender, ExitEventArgs e) {
            using (host) {
                await host.StopAsync();
            }
        }
    }
}