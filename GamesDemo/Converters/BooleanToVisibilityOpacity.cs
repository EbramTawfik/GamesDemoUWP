using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace GamesDemo.Converters
{

	public class BooleanToVisibilityOpacity : IValueConverter
	{
		public BooleanToVisibilityOpacity()
		{
		}

		public object Convert(object value, Type targetType, object parameter, string language)
		{
			if (value is bool && (bool)value)
			{
				return 1.0;
			}
			return 0;
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			return (value is double && (double)value == 1.0);
		}
	}

}
