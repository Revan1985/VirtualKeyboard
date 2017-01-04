using ManagedNativeWrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WW.WPF.VirtualKeyboard.ModelView;

namespace WW.WPF.VirtualKeyboard
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();

      DataContext = new KeyboardModelView();

      // In release, the size of control is the half bottom window.
      // In debug, just a 320x160, to test how it looks on little screens...

#if DEBUG

      Top = 100;
      Left = 100;
      Width = 320;
      Height = 160;

#else
      double width = SystemParameters.WorkArea.Width;
      double height = SystemParameters.WorkArea.Height;

      Top = height / 2.0;
      Left = 0.0;
      Width = width;
      Height = height / 2.0;
#endif
    }


    protected override void OnSourceInitialized(EventArgs e)
    {
      base.OnSourceInitialized(e);


      // To allow the window to work as a virtual keyboard, you must:
      // 1: Set the Hook for the WindowProc.
      // -  1: Prevent MouseActivate to happen, so you should return NoActivate as message
      // -  2: Prevent Window activation on Active and ClickActive action, re-focusing last window, this will work as ping-pong between screens (user will not understand it)
      // 2: Set the Style to noactivate and topmost
      // 3: Show the window as NoActivate.

      HwndSource source = PresentationSource.FromVisual(this) as HwndSource;
      source.AddHook(WndProc);

      IntPtr hWnd = source.Handle;

      // Set up the style.
      // Get from the current window, and add noactivate and top most.
      ExtendedWindowStyles style = (ExtendedWindowStyles)User32.GetWindowLong(hWnd, WindowLongEnum.ExStyle);
      style |= ExtendedWindowStyles.NoActivate | ExtendedWindowStyles.TopMost;

      // Set the modified style and show the window as default.
      User32.SetWindowLong(hWnd, WindowLongEnum.ExStyle, (int)style);
      User32.ShowWindow(hWnd, ShowWindowEnum.ShowDefault);
    }

    private IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
    {
      switch ((WindowMessages)msg)
      {
        case WindowMessages.MouseActivate:
          {
            // ok, this window must be not activated, either....
            handled = true;
            return new IntPtr((int)MouseActivate.NoActivate);
          }
        case WindowMessages.Activate:
          {
            switch ((WindowActivateEnum)wParam.ToInt32())
            {
              case WindowActivateEnum.Active:
              case WindowActivateEnum.ClickActive:
                {
                  if (!ReferenceEquals(lParam, IntPtr.Zero))
                  {
                    // Set the active window with the passed handle (lParam)
                    User32.SetActiveWindow(lParam);
                    IntPtr localHWnd = ((HwndSource)PresentationSource.FromVisual(this)).Handle;

                    // Set the window position as nomove, nosize, no active, and set as topmost.
                    // This will keep the window always on top of others (except if minimized)
                    User32.SetWindowPos(localHWnd, HWND.TopMost , 0, 0, 0, 0, SetWindowPositionFlag.NoMove | SetWindowPositionFlag.NoSize | SetWindowPositionFlag.NoActivate);
                  }
                }
                break;
            }
          }
          break;
      }

      return IntPtr.Zero;
    }
  }
}
