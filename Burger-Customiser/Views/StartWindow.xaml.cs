using Burger_Customiser_DAL.Database;
using Microsoft.Extensions.Logging;
using System.Windows;

namespace Burger_Customiser {

    /// <summary>
    /// Interaction logic for StartWindow.xaml
    /// </summary>
    public partial class StartWindow : Window {

        private readonly ILogger logger;

        private readonly ArticleDAL article;

        public StartWindow(ILogger<StartWindow> logger, ArticleDAL article) {
            this.logger = logger;

            this.article = article;
            InitializeComponent();
        }

        private void IdleScreenLMBDown(object sender, System.Windows.Input.MouseButtonEventArgs e) {
            logger.LogInformation("Starting Window...");
            Main.Content = new Pages.Bestelloption();
            IdleScreen.Visibility = Visibility.Hidden;

            logger.LogInformation(article.getArticles()[0].Name);
        }
    }
}