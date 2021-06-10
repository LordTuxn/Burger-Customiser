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
using System;
using System.Windows;

namespace Burger_Customiser {

    public partial class App : Application {
        private IHost host;
        private IConfiguration config;

        public App() {
           InitializeHost();
        }

        private void InitializeHost() {
            host = new HostBuilder()
                .ConfigureAppConfiguration((context, configurationBuilder) => {
                    configurationBuilder.SetBasePath(context.HostingEnvironment.ContentRootPath);
                    configurationBuilder.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                    config = configurationBuilder.Build();
                })
                .ConfigureServices(services => {
                    services.AddScoped<ApplicationDBContext>();

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