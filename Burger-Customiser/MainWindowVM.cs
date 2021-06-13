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

        // Register all view models
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

            BackButtonCommand = new RelayCommand(BackButton_Click);
            ContinueButtonCommand = new RelayCommand(ContinueButton_Click);

            ChangePage(new ChangePageMessage(typeof(StartPageVM)));
            
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