using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Burger_Customiser.Utils {

    public class UrlPathConverter : IValueConverter {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            try {
                string url = value.ToString().Trim();
                url = (url == "" ? "https://i.imgur.com/BnQNYQS.jpg" : url);
                // Check if there is a Background Image in the database, if not set default image

                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.UriSource = new Uri($"{url}", UriKind.RelativeOrAbsolute);
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();

                return new ImageBrush(bitmapImage) { Stretch = Stretch.UniformToFill };
            } catch {
                return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
}