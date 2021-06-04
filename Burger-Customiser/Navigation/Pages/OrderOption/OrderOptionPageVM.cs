using GalaSoft.MvvmLight;
using Microsoft.Extensions.Logging;
using System;

namespace Burger_Customiser.Navigation.Pages.OrderOption {

    public class OrderOptionPageVM : ViewModelBase, IPageViewModel {

        [Obsolete("Only for design data!", true)]
        public OrderOptionPageVM() {
            if (!IsInDesignMode) {
                throw new Exception("Use only for design mode");
            }
        }

        public OrderOptionPageVM(ILogger<OrderOptionPageVM> logger) {
            logger.LogInformation($"Successfully Registered: {nameof(OrderOptionPageVM)}");
        }

        public void ContinuePage() {
            throw new NotImplementedException();
        }

        public void BackPage() {
            throw new NotImplementedException();
        }
    }
}