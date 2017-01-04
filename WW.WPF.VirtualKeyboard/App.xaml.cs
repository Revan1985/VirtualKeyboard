using System.Globalization;
using System.Threading;
using System.Windows;
using System.Windows.Markup;

namespace WW.WPF.VirtualKeyboard
{
  /// <summary>
  /// Interaction logic for App.xaml
  /// </summary>
  public partial class App : Application
  {
    protected override void OnStartup(StartupEventArgs e)
    {
      base.OnStartup(e);

      Thread.CurrentThread.CurrentCulture = new CultureInfo("en-IN");
      Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-IN");
      FrameworkElement.LanguageProperty.OverrideMetadata(typeof(FrameworkElement), new FrameworkPropertyMetadata(
                  XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.IetfLanguageTag)));
    }
  }
}
