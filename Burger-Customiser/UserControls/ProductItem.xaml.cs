using Burger_Customiser_BLL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Burger_Customiser.UserControls
{
    /// <summary>
    /// Interaction logic for ProductItem.xaml
    /// </summary>
    public partial class ProductItem : UserControl
    {
        public ProductItem(Article article, int amount)
        {
            InitializeComponent();
            //TODO: Set Product name and price via Product class from constructor
            this.ProductName = article.Name;
            this.Amount = amount;
            this.Price = (double)article.Price;
        }

        private int amount;
        public int Amount
        {
            get { return amount; }
            set {
                if (value < 0) value = 0;
                if (value > 9) value = 9;
                TxtAmount.Text = $"{value}";
                amount = value; 
            }
        }

        private string productName;
        public string ProductName
        {
            get { return productName; }
            set {
                TxtName.Text = $"{value}";
                productName = value; 
            }
        }

        private double price;
        public double Price
        {
            get { return price; }
            set {
                TxtPrice.Text = $"{value}";
                price = value;
            }
        }

        private void BtnPlus_Click(object sender, RoutedEventArgs e)
        {
            Amount++;
        }

        private void BtnMinus_Click(object sender, RoutedEventArgs e)
        {
            Amount--;
        }
    }
}
