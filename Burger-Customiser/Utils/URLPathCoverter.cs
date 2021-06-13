using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Burger_Customiser.Utils {
    public class URLPathCoverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            try {
                string url = value.ToString().Trim();
                url = (url == "" ? "https://i.imgur.com/BnQNYQS.jpg" : url); 
                // Check if there is a Background Image in the database, if not set default image

                BitmapImage bitimg = new BitmapImage();
                bitimg.BeginInit();
                bitimg.UriSource = new Uri($"{url}", UriKind.RelativeOrAbsolute);
                bitimg.EndInit();

                return new ImageBrush(bitimg) { Stretch = Stretch.UniformToFill };
            } catch {
                return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            // lmao xd not gonna be implemented
            throw new NotImplementedException();
        }
    }
}
