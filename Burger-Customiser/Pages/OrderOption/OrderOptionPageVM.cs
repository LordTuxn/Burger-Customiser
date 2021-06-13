using System;
using Burger_Customiser.Messages;
using Burger_Customiser.Pages.Start;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.Extensions.Logging;

namespace Burger_Customiser.Pages.OrderOption {

    public class OrderOptionPageVM : PageViewModelBase {
        private readonly ILogger<OrderOptionPageVM> _logger;

        [Obsolete("Only for design data!", true)]
        public OrderOptionPageVM() {
            if (!IsInDesignMode) {
                throw new Exception("Use only for design mode");
            }
        }

        public OrderOptionPageVM(ILogger<OrderOptionPageVM> logger) {
            _logger = logger;
            logger.LogInformation($"Successfully Registered: {nameof(OrderOptionPageVM)}");
        }

        public override NavigationButton GetBackButton() {
            return new NavigationButton("ZURÜCK", onClick => {
                _logger.LogInformation("Yes!");
                Messenger.Default.Send(new ChangePageMessage(typeof(StartPageVM)));
            });
        }

        public override NavigationButton GetContinueButton() { return null; }

    }
}