using System;
using System.Windows.Controls;
using System.Windows.Input;

namespace Burger_Customiser.Pages {

    /// <summary>
    /// Interaction logic for Bestelloption.xaml
    /// </summary>
    public partial class OrderOptionPage : Page {

        private readonly PageManager pageManager;

        public OrderOptionPage(PageManager pageManager) {
            this.pageManager = pageManager;

            InitializeComponent();
        }

        private void EatHereLMBDown(object sender, MouseButtonEventArgs e) {
            pageManager.NextPage();
        }

        private void TakeawayLMBDown(object sender, MouseButtonEventArgs e) {
            pageManager.NextPage();
        }
    }
}
