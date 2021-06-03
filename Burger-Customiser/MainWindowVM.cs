using Burger_Customiser.Navigation.Messages;
using Burger_Customiser.Navigation.Pages.OrderOption;
using Burger_Customiser.Navigation.Pages.Start;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using System;

namespace Burger_Customiser {

    public class MainWindowVM : ViewModelBase {
        private ViewModelBase currentViewModel;

        public ViewModelBase CurrentViewModel {
            get { return currentViewModel; }
            set { Set(ref currentViewModel, value); }
        }

        public RelayCommand ShowStartPageCommand { get; private set; }
        public RelayCommand ShowOrderOptionPageCommand { get; private set; }

        /// <summary>
        /// Register all view models
        /// </summary>
        private readonly StartPageVM startPageVM;

        private readonly OrderOptionPageVM orderOptionPageVM;

        public MainWindowVM(StartPageVM startPageVM, OrderOptionPageVM orderOptionPageVM) {
            this.startPageVM = startPageVM;
            this.orderOptionPageVM = orderOptionPageVM;

            ShowStartPageCommand = new RelayCommand(ShowStartPage);
            ShowOrderOptionPageCommand = new RelayCommand(ShowOrderOptionPage);

            ShowStartPage();

            // Register messanger for all pages
            Messenger.Default.Register<ChangePageMessage>(this, ChangePage);
        }

        private void ShowStartPage() {
            CurrentViewModel = startPageVM;
        }

        private void ShowOrderOptionPage() {
            CurrentViewModel = orderOptionPageVM;
        }

        [Obsolete("Only for design data!", true)]
        public MainWindowVM() {
            if (!IsInDesignMode) {
                throw new Exception("Use only for design mode");
            }
        }

        private void ChangePage(ChangePageMessage page) {
            if (page.ViewModelType == typeof(StartPageVM)) {
                ShowStartPage();
            } else if (page.ViewModelType == typeof(OrderOptionPageVM)) {
                ShowOrderOptionPage();
            }
        }
    }
}