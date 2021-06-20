using System;
using Burger_Customiser.Messages;
using Burger_Customiser.Pages.ArticleOption;
using Burger_Customiser.Pages.Start;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.Extensions.Logging;

namespace Burger_Customiser.Pages.OrderOption {

    public class OrderOptionPageVM : PageViewModelBase {
        private readonly ILogger<OrderOptionPageVM> _logger;

        public OrderManager OrderManager { get; }

        public RelayCommand EatHere_Command { get; }
        public RelayCommand Takeaway_Command { get; }

        [Obsolete("Only for design data!", true)]
        public OrderOptionPageVM() {
            if (!IsInDesignMode) {
                throw new Exception("Use only for design mode");
            }
        }

        public OrderOptionPageVM(ILogger<OrderOptionPageVM> logger, OrderManager orderManager) {
            _logger = logger;
            OrderManager = orderManager;

            EatHere_Command = new RelayCommand(EatHere_Click);
            Takeaway_Command = new RelayCommand(Takeaway_Click);

            logger.LogInformation($"Successfully Registered: {nameof(OrderOptionPageVM)}");
        }

        public override NavigationButton GetBackButton() {
            return new NavigationButton("ZURÜCK", onClick => {
                Messenger.Default.Send(new ChangePageMessage(typeof(StartPageVM)));
            });
        }

        public override NavigationButton GetContinueButton() { return null; }

        public void EatHere_Click() {
            OrderManager.Order.ToTakeAway = false;
            Messenger.Default.Send(new ChangePageMessage(typeof(ArticleOptionPageVM)));
        }

        public void Takeaway_Click() {
            OrderManager.Order.ToTakeAway = true;
            Messenger.Default.Send(new ChangePageMessage(typeof(ArticleOptionPageVM)));
        }
    }
}