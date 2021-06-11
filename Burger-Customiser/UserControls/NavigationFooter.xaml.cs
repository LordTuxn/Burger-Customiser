using System.Windows;
using System.Windows.Controls;

namespace Burger_Customiser.UserControls {

    /// <summary>
    /// Interaction logic for NavigationFooter.xaml
    /// </summary>
    public partial class NavigationFooter : UserControl {

        public NavigationFooter(PageManager pm) {
            InitializeComponent();
            Grid.SetColumn(this, 1);
            Grid.SetRow(this, 4);
            this.pageManager = pm;
        }

        private readonly PageManager pageManager;

        private void Button_Next_Click(object sender, RoutedEventArgs e) {
            pageManager.NextPage();
        }

        private void Button_Back_Click(object sender, RoutedEventArgs e) {
            pageManager.PreviousPage();
        }
    }
}