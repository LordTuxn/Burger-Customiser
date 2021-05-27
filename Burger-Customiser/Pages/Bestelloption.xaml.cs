using System.Windows.Controls;
using System.Windows.Input;

namespace Burger_Customiser.Pages {

    /// <summary>
    /// Interaction logic for Bestelloption.xaml
    /// </summary>
    public partial class Bestelloption : Page {

        private readonly PageManager pageManager;

        public Bestelloption(PageManager pageManager) {
            this.pageManager = pageManager;

            InitializeComponent();
        }

        private void EatHereLMBDown(object sender, MouseButtonEventArgs e) {
            pageManager.Navigate(MenuPages.Artikeloption);
        }

        private void TakeawayLMBDown(object sender, MouseButtonEventArgs e) {
            pageManager.Navigate(MenuPages.Artikeloption);
        }
    }
}
