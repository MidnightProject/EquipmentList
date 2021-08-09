using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace EquipmentList.Converters
{
    public class BackgroundToForegroundConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return Brushes.Black;
            }

            Color color = ((SolidColorBrush)value).Color;

            if (color.R * 0.2126 + color.G * 0.7152 + color.B * 0.0722 < 50 && color.A > 100)
            {
                return Brushes.White;
            }
            else
            {
                return Brushes.Black;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
