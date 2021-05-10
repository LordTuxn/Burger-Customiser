using Burger_Customiser_DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace Burger_Customiser {

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application {
        private readonly ServiceProvider serviceProvider;

        public App() {
            ServiceCollection services = new ServiceCollection();
            ConfigureServices(services);
            serviceProvider = services.BuildServiceProvider();
        }

        private void ConfigureServices(IServiceCollection services) {
            services.AddEntityFrameworkSqlite()
                .AddDbContext<ArticleDBContext>(options => {
                    options.UseSqlite("Connection");
                });

            services.AddSingleton<StartWindow>();
        }

        private void OnStartup(object sender, StartupEventArgs e) {
            serviceProvider.GetService<StartWindow>().Show();
        }
    }
}