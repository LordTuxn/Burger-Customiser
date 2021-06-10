using Burger_Customiser.Navigation.Pages.Catalogue;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Windows.Controls;
using Burger_Customiser.Messages;
using Burger_Customiser.Pages.ArticleOption;
using Burger_Customiser.Pages.OrderOption;
using Burger_Customiser.Pages.Start;

namespace Burger_Customiser {

    public class MainWindowVM : ViewModelBase {
        
        private ViewModelBase _currentViewModel;
        public ViewModelBase CurrentViewModel {
            get => _currentViewModel;
            set => Set(ref _currentViewModel, value);
        }

        public RelayCommand ShowStartPageCommand { get; private set; }
        public RelayCommand ShowOrderOptionPageCommand { get; private set; }
        public RelayCommand ShowArticleOptionPageCommand { get; private set; }

        /// <summary>
        /// Register all view models
        /// </summary>
        private readonly StartPageVM _startPageVm;
        private readonly OrderOptionPageVM _orderOptionPageVm;
        private readonly ArticleOptionPageVM _articleOptionPageVm;
        private readonly CataloguePageVM _cataloguePageVm;

        public MainWindowVM(StartPageVM startPageVM, OrderOptionPageVM orderOptionPageVM,
                            ArticleOptionPageVM articleOptionPageVM, CataloguePageVM cataloguePageVM) {
            _startPageVm = startPageVM;
            _orderOptionPageVm = orderOptionPageVM;
            _articleOptionPageVm = articleOptionPageVM;
            _cataloguePageVm = cataloguePageVM;

            ShowStartPageCommand = new RelayCommand(ShowStartPage);
            ShowOrderOptionPageCommand = new RelayCommand(ShowOrderOptionPage);

            ShowCataloguePage();

            // Register messenger for changing pages
            Messenger.Default.Register<ChangePageMessage>(this, ChangePage);
        }

        private void ShowStartPage() {
            CurrentViewModel = _startPageVm;
        }

        private void ShowOrderOptionPage() {
            CurrentViewModel = _orderOptionPageVm;
        }

        private void ShowArticleOptionPage() {
            CurrentViewModel = _articleOptionPageVm;
        }

        private void ShowCataloguePage() {
            CurrentViewModel = _cataloguePageVm;
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
            } else if(page.ViewModelType == typeof(CataloguePageVM)) {
                // TODO: Show Confirmation Page
            }
        }

        private void ContinueButton_Click() {
            if(CurrentViewModel is ArticleOptionPageVM) {
                _articleOptionPageVm.ContinuePage();
                
            }
        }
    }
}