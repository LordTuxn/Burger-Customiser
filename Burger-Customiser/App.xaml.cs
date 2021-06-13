using Burger_Customiser_DAL;
using Burger_Customiser_DAL.Database;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Windows;
using Burger_Customiser.Pages.ArticleOption;
using Burger_Customiser.Pages.Catalogue;
using Burger_Customiser.Pages.OrderOption;
using Burger_Customiser.Pages.Start;

namespace Burger_Customiser {

    public partial class App : Application {
        private IHost _host;
        private IConfiguration _config;

        private void InitializeHost() {
            _host = new HostBuilder()
                .ConfigureAppConfiguration((context, configurationBuilder) => {
                    configurationBuilder.SetBasePath(context.HostingEnvironment.ContentRootPath);
                    configurationBuilder.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                    _config = configurationBuilder.Build();
                })
                .ConfigureServices(services => {
                    services.AddScoped<ApplicationDbContext>();

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
                    logging.AddConfiguration(_config.GetSection("Logging"));
                    logging.AddDebug();
                })
                .Build();
        }

        private async void Application_Startup(object sender, StartupEventArgs e) {
            InitializeHost();

            await _host.StartAsync();

            _host.Services.GetService<MainWindow>()?.Show();
        }

        private async void Application_Exit(object sender, ExitEventArgs e) {
            using (_host) {
                await _host.StopAsync();
            }
        }
    }
}