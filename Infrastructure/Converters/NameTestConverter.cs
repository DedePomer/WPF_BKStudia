﻿using System.Globalization;
using System.Windows.Data;

namespace WPF_BKStudia.Infrastructure.Converters
{
    public class NameTestConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string newString = (string)value;
            return newString.Replace(".txt", "").Replace("Tests", "").Replace("\\", "");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
