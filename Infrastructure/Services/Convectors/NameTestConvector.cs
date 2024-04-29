using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WPF_BKStudia.Infrastructure.Services.Convectors
{
    public class NameTestConvector : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string newString = (string)value;
            return newString.Replace(".txt", "").Replace("Tests", "").Replace("\\", "").Replace("!", ""); 
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
