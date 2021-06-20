using System;
using System.Globalization;
using System.Windows.Data;

namespace Burger_Customiser.Utils {

    public class ArticleListRowsConverter : IValueConverter {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            // Set min size of rows to prevent a higher height for article items
            return (int)value <= 3 ? 3 : value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
}