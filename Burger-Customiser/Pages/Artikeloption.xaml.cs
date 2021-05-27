using System.Windows.Controls;
using System.Windows.Input;

namespace Burger_Customiser.Pages {

    /// <summary>
    /// Interaction logic for Artikeloption.xaml
    /// </summary>
    public partial class Artikeloption : Page {
        private readonly PageManager pageManager;

        public Artikeloption(PageManager pageManager) {
            this.pageManager = pageManager;

            InitializeComponent();
        }

        private void BurgerLMBDown(object sender, MouseButtonEventArgs e) {
            pageManager.Navigate(MenuPages.BurgerCustomiser);
        }

        private void CatalogueLMBDown(object sender, MouseButtonEventArgs e) {

        }
    }
}
