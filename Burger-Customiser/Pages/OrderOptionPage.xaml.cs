using System.Windows.Controls;
using System.Windows.Input;

namespace Burger_Customiser.Pages {

    /// <summary>
    /// Interaction logic for Bestelloption.xaml
    /// </summary>
    public partial class OrderOptionPage : Page {

        private readonly PageManager pageManager;
        private readonly OrderManager orderManager;

        public OrderOptionPage(PageManager pageManager) {
            this.pageManager = pageManager;
        //    this.orderManager = orderManager;

            InitializeComponent();
        }

        private void EatHereLMBDown(object sender, MouseButtonEventArgs e) {
            // orderManager.Order.ToTakeAway = false;

            pageManager.Navigate(MenuPages.ArticleOption);
        }

        private void TakeawayLMBDown(object sender, MouseButtonEventArgs e) {
            // orderManager.Order.ToTakeAway = true;

            pageManager.Navigate(MenuPages.ArticleOption);
        }
    }
}
