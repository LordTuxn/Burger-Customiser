using Burger_Customiser_BLL;
using GalaSoft.MvvmLight;

namespace Burger_Customiser.Pages.Catalogue {

    public class ArticleItem : ViewModelBase {
        public Article Article { get; }

        private int _amount;

        public int Amount {
            get => _amount;
            set => Set(ref _amount, value);
        }

        public string FormattedPrice { get; }

        public ArticleItem(Article article) {
            Article = article;

            FormattedPrice = $"{Article.Price} €";
        }

        public bool AddArticle() {
            if (Amount >= 9) {
                Amount = 9;
                return false;
            }
            Amount += 1;
            return true;
        }

        public bool RemoveArticle() {
            if (Amount <= 0) {
                Amount = 0;
                return false;
            }
            Amount -= 1;
            return true;
        }
    }
}