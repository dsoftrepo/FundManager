using System;
using System.Globalization;
using System.Windows.Data;

namespace FundManager.BusinessLogic
{
    public class Tolerance : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (decimal)value < 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return true;
        }
    }
}
