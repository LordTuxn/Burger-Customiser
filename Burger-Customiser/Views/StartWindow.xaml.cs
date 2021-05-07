using System.Windows;

namespace Burger_Customiser {

    /// <summary>
    /// Interaction logic for StartWindow.xaml
    /// </summary>
    public partial class StartWindow : Window {

        public StartWindow() {
            InitializeComponent();
        }

        private void IdleScreenLMBDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Main.Content = new Pages.Bestelloption();
            IdleScreen.Visibility = Visibility.Hidden;
        }
    }
}