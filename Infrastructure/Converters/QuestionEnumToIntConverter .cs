using System.Globalization;
using System.Windows.Data;
using WPF_BKStudia.Infrastructure.Enums;

namespace WPF_BKStudia.Infrastructure.Converters
{
    public class QuestionEnumToIntConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (int)value;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (QuestionEnum)value;
        }
    }
}
