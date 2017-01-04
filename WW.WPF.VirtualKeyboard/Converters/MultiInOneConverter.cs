using System;
using System.Linq;

using System.Globalization;
using System.Windows.Data;
using ManagedNativeWrapper;

namespace WW.WPF.VirtualKeyboard.Converters
{
  public class MultiInOneConverter : IMultiValueConverter
  {
    /// <summary>
    /// Convert the given object[] to a char[] or a VirtualKeyCode[]
    /// </summary>
    /// <param name="values">Values to convert</param>
    /// <param name="targetType">target type (not used)</param>
    /// <param name="parameter">parameter (not used)</param>
    /// <param name="culture">Culture Info (not used)</param>
    /// <returns>char[] or VirtualKeyCode[]</returns>
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
      try
      {
        Type t = values[0].GetType();
        if (t == typeof(VirtualKeyCode))
        {
          return values.Where(v =>
          {
            return v.GetType() == typeof(VirtualKeyCode);
          }).Cast<VirtualKeyCode>().ToArray();
        }

        return values.Where(v =>
        {
          return v.GetType() == typeof(char);
        }).Cast<char>().ToArray();
      }
      catch
      {
        return values.Clone();
      }
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
      throw new NotImplementedException();
    }
  }
}
