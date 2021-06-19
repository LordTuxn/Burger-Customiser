using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Windows;
using System.Windows.Controls;
using Burger_Customiser.Messages;
using Burger_Customiser.Pages;
using Burger_Customiser.Pages.ArticleOption;
using Burger_Customiser.Pages.Catalogue;
using Burger_Customiser.Pages.Confirmation;
using Burger_Customiser.Pages.OrderOption;
using Burger_Customiser.Pages.ShoppingCart;
using Burger_Customiser.Pages.Start;

namespace Burger_Customiser {

    public class MainWindowVM : ViewModelBase {

        private Button _continueButton;
        public Button ContinueButton {
            get => _continueButton;
            set => Set(ref _continueButton, value);
        }

        private Button _backButton;
        public Button BackButton {
            get => _backButton;
            set => Set(ref _backButton, value);
        }

        private PageViewModelBase _currentViewModel;
        public PageViewModelBase CurrentViewModel {
            get => _currentViewModel;
            set => Set(ref _currentViewModel, value);
        }

        private Visibility _isShoppingCartIconVisible;
        public Visibility IsShoppingCartIconVisible {
            get => _isShoppingCartIconVisible;
            set => Set(ref _isShoppingCartIconVisible, value);
        }


        public RelayCommand BackButtonCommand { get; set; }

        public RelayCommand ContinueButtonCommand { get; set; }

        private readonly StartPageVM _startPage;
        private readonly OrderOptionPageVM _orderOptionPage;
        private readonly ArticleOptionPageVM _articleOptionPage;
        private readonly CataloguePageVM _cataloguePage;
        private readonly ShoppingCartPageVM _shoppingCartPage;
        private readonly ConfirmationPageVM _confirmationPage;

        public MainWindowVM(StartPageVM startPage, OrderOptionPageVM orderOptionPage, 
            ArticleOptionPageVM articleOptionPage, CataloguePageVM cataloguePage,
            ShoppingCartPageVM shoppingCartPage, ConfirmationPageVM confirmationPage) {
            _startPage = startPage;
            _orderOptionPage = orderOptionPage;
            _articleOptionPage = articleOptionPage;
            _cataloguePage = cataloguePage;
            _shoppingCartPage = shoppingCartPage;
            _confirmationPage = confirmationPage;

            BackButtonCommand = new RelayCommand(BackButton_Click);
            ContinueButtonCommand = new RelayCommand(ContinueButton_Click);

            ChangePage(new ChangePageMessage(typeof(StartPageVM)));
            
            // Register messenger for changing pages
            Messenger.Default.Register<ChangePageMessage>(this, ChangePage);
        }

        private void ShowStartPage() {
            CurrentViewModel = _startPage;
        }

        private void ShowOrderOptionPage() {
            CurrentViewModel = _orderOptionPage;
        }

        private void ShowArticleOptionPage() {
            CurrentViewModel = _articleOptionPage;
        }

        private void ShowCataloguePage() {
            CurrentViewModel = _cataloguePage;
        }

        private void ShowShoppingCartPage() {
            CurrentViewModel = _shoppingCartPage;
        }

        private void ShowConfirmationPage() {
            CurrentViewModel = _confirmationPage;
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
            } else if(page.ViewModelType == typeof(ShoppingCartPageVM)) {
                ShowShoppingCartPage();
            } else {
                ShowConfirmationPage();
            }

            if (page.ViewModelType == typeof(ArticleOptionPageVM) || page.ViewModelType == typeof(CataloguePageVM)) {
                IsShoppingCartIconVisible = Visibility.Visible;
            } else {
                IsShoppingCartIconVisible = Visibility.Hidden;
            }

            BackButton = CurrentViewModel?.GetBackButton() != null ?
                CurrentViewModel.GetBackButton() : null;

            ContinueButton = CurrentViewModel?.GetContinueButton() != null ?
                CurrentViewModel.GetContinueButton() : null;
        }

        private void BackButton_Click() {
            CurrentViewModel.GetBackButton().ExecuteClickAction(BackButton);
        }

        private void ContinueButton_Click() {
            CurrentViewModel.GetContinueButton().ExecuteClickAction(ContinueButton);
        }
    }
}