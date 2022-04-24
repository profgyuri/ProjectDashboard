using System;
using System.Globalization;
using System.Windows.Data;

namespace ProjectDashboard;

public class BoolToVisibilityConverter : IValueConverter
{
    public object Convert(object value, Type targetType,
        object parameter, CultureInfo culture)
    {
        var bValue = (bool) value;

        if (bValue)
        {
            return System.Windows.Visibility.Visible;
        }

        return System.Windows.Visibility.Collapsed;
    }

    public object ConvertBack(object value, Type targetType,
        object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}