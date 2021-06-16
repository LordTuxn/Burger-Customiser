using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Windows.Controls;
using Burger_Customiser.Messages;
using Burger_Customiser.Pages;
using Burger_Customiser.Pages.ArticleOption;
using Burger_Customiser.Pages.Catalogue;
using Burger_Customiser.Pages.OrderOption;
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

        public RelayCommand BackButtonCommand { get; set; }

        public RelayCommand ContinueButtonCommand { get; set; }

        private readonly StartPageVM _startPage;
        private readonly OrderOptionPageVM _orderOptionPage;
        private readonly ArticleOptionPageVM _articleOptionPage;
        private readonly CataloguePageVM _cataloguePage;

        public MainWindowVM(StartPageVM startPage, OrderOptionPageVM orderOptionPage, 
            ArticleOptionPageVM articleOptionPage, CataloguePageVM cataloguePage) {
            _startPage = startPage;
            _orderOptionPage = orderOptionPage;
            _articleOptionPage = articleOptionPage;
            _cataloguePage = cataloguePage;

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