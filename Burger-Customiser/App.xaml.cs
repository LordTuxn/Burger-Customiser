using Burger_Customiser_DAL;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System.Windows;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Hosting;
using System;
using Burger_Customiser_DAL.Database;
using Microsoft.EntityFrameworkCore;
using Burger_Customiser.Pages;

namespace Burger_Customiser {

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application {

        private readonly IHost host;
        private IConfiguration config;

        public App() {
            host = new HostBuilder()
                .ConfigureAppConfiguration((context, configurationBuilder) => {
                    configurationBuilder.SetBasePath(context.HostingEnvironment.ContentRootPath);
                    configurationBuilder.AddJsonFile("appsettings.json", optional: false);
                    config = configurationBuilder.Build();
                })
                .ConfigureServices((context, services) => {

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

                    // Inject Database DALs
                    services.AddSingleton<ArticleDAL>();
                    services.AddSingleton<BurgerDAL>();
                    services.AddSingleton<CategoryDAL>();

                    // Inject Pages
                    services.AddScoped<StartSitePage>();
                    services.AddScoped<OrderOptionPage>();
                    services.AddScoped<ArticleOptionPage>();
                    services.AddScoped<Catalogue>();

                    // Inject Application Window and Managers
                    services.AddSingleton<OrderManager>();
                    services.AddSingleton<PageManager>();

                    services.AddSingleton<StartWindow>();
                })
                .ConfigureLogging(logging => {
                    logging.AddConfiguration(config.GetSection("Logging"));
                    logging.AddDebug();
                })
                .Build();
        }

        private async void Application_Startup(object sender, StartupEventArgs args) {
            await host.StartAsync();

            host.Services.GetService<PageManager>().Navigate(MenuPages.StartSite);
            host.Services.GetService<StartWindow>().Show();
        }

        private async void Application_Exit(object sender, ExitEventArgs e) {
            using (host) {
                await host.StopAsync(TimeSpan.FromSeconds(5));
            }
        }
    }
}