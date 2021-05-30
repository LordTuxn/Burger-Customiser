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
using Ninject;
using Ninject.Modules;

namespace Burger_Customiser {

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application {

        private readonly IHost host;
        private IConfiguration config;

        private IKernel kernal;

        public App() {
            host = new HostBuilder()
                .ConfigureAppConfiguration((context, configurationBuilder) => {
                    configurationBuilder.SetBasePath(context.HostingEnvironment.ContentRootPath);
                    configurationBuilder.AddJsonFile("appsettings.json", optional: false);
                    config = configurationBuilder.Build();
                })
                .ConfigureLogging(logging => {
                    logging.AddConfiguration(config.GetSection("Logging"));
                    logging.AddDebug();
                })
                .Build();

            kernal = new StandardKernel();
            

            kernal.Bind<StartWindow>().ToSelf().InSingletonScope();
        }

        private async void Application_Startup(object sender, StartupEventArgs args) {
            await host.StartAsync();

            kernal.Get<StartWindow>().Show();
            //host.Services.GetService<PageManager>().Navigate(MenuPages.StartSite);
            //host.Services.GetService<StartWindow>().Show();
        }

        private async void Application_Exit(object sender, ExitEventArgs e) {
            using (host) {
                await host.StopAsync(TimeSpan.FromSeconds(5));
            }
        }
    }
}