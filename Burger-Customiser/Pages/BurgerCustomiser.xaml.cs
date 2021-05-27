using System.Windows.Controls;

namespace Burger_Customiser.Pages {

    /// <summary>
    /// Interaction logic for BurgerCustomiser.xaml
    /// </summary>
    public partial class BurgerCustomiser : Page {

        private readonly PageManager pageManager;

        public BurgerCustomiser(PageManager pageManager) {
            this.pageManager = pageManager;

            InitializeComponent();
        }
    }
}
