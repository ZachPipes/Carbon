using System;
using System.Globalization;
using Avalonia.Data.Converters;
using Avalonia.Media;

namespace Carbon.Services.Converters;

public class SectionToForegroundConverter : IValueConverter {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
        String selected = value?.ToString();
        String current = parameter?.ToString();
        return selected == current
            ? Brushes.White
            : Brushes.DarkGray;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
        throw new NotImplementedException();
    }
}