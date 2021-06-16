using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.ComponentModel;
using System.Windows.Controls;
using Burger_Customiser.Messages;
using Burger_Customiser.Pages;
using Burger_Customiser.Pages.ArticleOption;
using Burger_Customiser.Pages.Catalogue;
using Burger_Customiser.Pages.OrderOption;
using Burger_Customiser.Pages.Start;
using Microsoft.Extensions.DependencyInjection;

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

        private readonly IServiceProvider services;

        public MainWindowVM(IServiceProvider services) {
            this.services = services;

            BackButtonCommand = new RelayCommand(BackButton_Click);
            ContinueButtonCommand = new RelayCommand(ContinueButton_Click);

            ChangePage(new ChangePageMessage(typeof(StartPageVM)));
            
            // Register messenger for changing pages
            Messenger.Default.Register<ChangePageMessage>(this, ChangePage);
        }

        private void ShowStartPage() {
            CurrentViewModel = services.GetRequiredService<StartPageVM>();
        }

        private void ShowOrderOptionPage() {
            CurrentViewModel = services.GetRequiredService<OrderOptionPageVM>();
        }

        private void ShowArticleOptionPage() {
            CurrentViewModel = services.GetRequiredService<ArticleOptionPageVM>();
        }

        private void ShowCataloguePage(CatalogueType type) {
            var catalogue = services.GetRequiredService<CataloguePageVM>();
            catalogue.CatalogueType = type;
            CurrentViewModel = catalogue;
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
                ShowCataloguePage(page.CatalogueType);
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