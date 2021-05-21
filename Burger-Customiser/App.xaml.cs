using Burger_Customiser_DAL;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System.Windows;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Hosting;
using System;
using Burger_Customiser_DAL.Database;
using Microsoft.EntityFrameworkCore;

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
                    // Add Services
                    string connectionString = config["Data:Database:ConnectionString"];
                    services.AddDbContextPool<ApplicationDBContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

                    services.AddScoped<ArticleDAL>();

                    services.AddSingleton<StartWindow>();
                })
                .ConfigureLogging(logging => {
                    logging.AddDebug();
                })
                .Build();
        }

        private async void Application_Startup(object sender, StartupEventArgs args) {
            await host.StartAsync();

            host.Services.GetService<StartWindow>().Show();
        }

        private async void Application_Exit(object sender, ExitEventArgs e) {
            using (host) {
                await host.StopAsync(TimeSpan.FromSeconds(5));
            }
        }
    }
}