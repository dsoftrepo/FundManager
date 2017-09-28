using System;
using System.Globalization;
using System.Windows.Data;
using FundManager.Model;

namespace FundManager.BusinessLogic
{
    public class TransactionToleranceCost : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return values[0].ToString() == StockType.Bond.ToString() ? (decimal)values[1] > 100000 : (decimal)values[1] > 200000;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
