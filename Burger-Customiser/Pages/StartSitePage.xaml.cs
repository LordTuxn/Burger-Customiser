using System;
using System.Windows.Controls;
using System.Windows.Input;

namespace Burger_Customiser.Pages {

    /// <summary>
    /// Interaction logic for StartSite.xaml
    /// </summary>
    public partial class StartSitePage : Page, IDisposable {

        private readonly PageManager pageManager;

        public StartSitePage(PageManager pageManager) {
            this.pageManager = pageManager;

            InitializeComponent();
        }

        private void IdleScreenLMBDown(object sender, MouseButtonEventArgs e) {
            pageManager.Navigate(MenuPages.OrderOption);
        }

        public void Dispose() {
            this.Dispose();
        }
    }
}
