namespace TwitterFeederApp.UI.Converters
{
    using System;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Data;
    
    /// <summary>
    /// Converts boolean to visibility, visible if passed value is true else collapsed
    /// </summary>
    /// <remarks>
    /// Details and Preferences module use it.
    /// </remarks>    
    public class BoolToVisibilityConverter : IValueConverter
    {
        /// <summary>
        /// Converts boolean to visibility.
        /// </summary>
        /// <param name="value">True or false.</param>
        /// <param name="targetType">The type of the binding target property.</param>
        /// <param name="parameter">Set parameter to Hidden if false value needs to translate to Visibility.Hidden otherwise false value will be treated as Visibility.Collapsed.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>A converted value. True is converted to visible else collapsed or hidden based on parameter value</returns>
        public object Convert(object value, Type targetType, object parameter, string culture)
        {
            Visibility result = Visibility.Collapsed;

            if (value != null)
            {
                if ((bool)value)
                {
                    result = Visibility.Visible;
                }
                else
                {
                    result = Visibility.Collapsed;                    
                }
            }

            return result;
        }

        /// <summary>
        /// Converts a value.
        /// </summary>
        /// <param name="value">The value that is produced by the binding target.</param>
        /// <param name="targetType">The type to convert to.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>A converted value.</returns>
        public object ConvertBack(object value, Type targetType, object parameter, string culture)
        {
            Visibility visibility = (Visibility)value;
            return visibility == Visibility.Visible;
        }
    }
}