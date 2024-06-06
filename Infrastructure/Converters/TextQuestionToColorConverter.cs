using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace WPF_BKStudia.Infrastructure.Converters
{
    class TextQuestionToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((bool)value)
            {
                case true:
                    return new SolidColorBrush(Colors.LightBlue);
                case false:
                    return new SolidColorBrush(Colors.MediumVioletRed);
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
