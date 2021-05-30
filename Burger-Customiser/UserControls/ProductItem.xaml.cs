using Burger_Customiser_BLL;
using System.Windows;
using System.Windows.Controls;

namespace Burger_Customiser.UserControls {

    /// <summary>
    /// Interaction logic for ProductItem.xaml
    /// </summary>
    public partial class ProductItem : UserControl {

        private readonly CatalogueList catalogue;
        private readonly Article article;

        public ProductItem(CatalogueList catalogue, Article article, int amount) {
            this.catalogue = catalogue;
            this.article = article;

            InitializeComponent();

            this.ProductName = article.Name;
            this.Amount = amount;
            this.Price = (double)article.Price;
        }

        private int amount;
        public int Amount {
            get { return amount; }
            set {
                if (value < 0) value = 0;
                if (value > 9) value = 9;
                TxtAmount.Text = $"{value}";
                amount = value;

                if (!catalogue.articleOrders.ContainsKey(article) && value >= 1) {
                    catalogue.articleOrders.Add(article, Amount);
                } else if(value <= 9) {
                    catalogue.articleOrders[article] = amount;
                } else {
                    catalogue.articleOrders.Remove(article);
                }
            }
        }

        private string productName;
        public string ProductName {
            get { return productName; }
            set {
                TxtName.Text = $"{value}";
                productName = value;
            }
        }

        private double price;
        public double Price {
            get { return price; }
            set {
                TxtPrice.Text = $"{value}";
                price = value;
            }
        }

        private void BtnPlus_Click(object sender, RoutedEventArgs e) {
            Amount++;
        }

        private void BtnMinus_Click(object sender, RoutedEventArgs e) {
            Amount--;
        }
    }
}