using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace GI.UI
{
    public sealed class SelectedIndexToTrueConverter : IValueConverter
    {
        public bool IsInverted { get; set; }

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var index = (int) value;
            return index < 0 ^ IsInverted;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return DependencyProperty.UnsetValue;
        }
    }
}
