using Burger_Customiser.Navigation.Messages;
using Burger_Customiser.Navigation.Pages.ArticleOption;
using Burger_Customiser.Navigation.Pages.Catalogue;
using Burger_Customiser.Navigation.Pages.OrderOption;
using Burger_Customiser.Navigation.Pages.Start;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Windows.Controls;

namespace Burger_Customiser {

    public class MainWindowVM : ViewModelBase {
        
        private ViewModelBase currentViewModel;
        public ViewModelBase CurrentViewModel {
            get { return currentViewModel; }
            set { Set(ref currentViewModel, value); }
        }

        private Button continueButton;
        public Button ContinueButton {
            get { return continueButton; }
            set { Set(ref continueButton, value); }
        }

        private Button backButton;
        public Button BackButton {
            get { return backButton; }
            set { Set(ref backButton, value); }
        }

        public RelayCommand ShowStartPageCommand { get; private set; }
        public RelayCommand ShowOrderOptionPageCommand { get; private set; }
        public RelayCommand ShowArticleOptionPageCommand { get; private set; }

        /// <summary>
        /// Register all view models
        /// </summary>
        private readonly StartPageVM startPageVM;
        private readonly OrderOptionPageVM orderOptionPageVM;
        private readonly ArticleOptionPageVM articleOptionPageVM;
        private readonly CataloguePageVM cataloguePageVM;

        public MainWindowVM(StartPageVM startPageVM, OrderOptionPageVM orderOptionPageVM,
                            ArticleOptionPageVM articleOptionPageVM, CataloguePageVM cataloguePageVM) {
            this.startPageVM = startPageVM;
            this.orderOptionPageVM = orderOptionPageVM;
            this.articleOptionPageVM = articleOptionPageVM;
            this.cataloguePageVM = cataloguePageVM;

            ShowStartPageCommand = new RelayCommand(ShowStartPage);
            ShowOrderOptionPageCommand = new RelayCommand(ShowOrderOptionPage);

            ShowCataloguePage();

            // Register messanger for all pages
            Messenger.Default.Register<ChangePageMessage>(this, ChangePage);
        }

        private void ShowStartPage() {
            CurrentViewModel = startPageVM;
        }

        private void ShowOrderOptionPage() {
            CurrentViewModel = orderOptionPageVM;
        }

        private void ShowArticleOptionPage() {
            CurrentViewModel = articleOptionPageVM;
        }

        private void ShowCataloguePage() {
            CurrentViewModel = cataloguePageVM;
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
            } else if(page.ViewModelType == typeof(ArticleOptionPageVM)) {
                ShowArticleOptionPage();
            } else if(page.ViewModelType == typeof(CataloguePageVM)) {
                ShowCataloguePage();
            }
        }

        private void ContinueButton_Click() {
            if(CurrentViewModel is ArticleOptionPageVM) {
                articleOptionPageVM.ContinuePage();
                
            }
        }
    }
}