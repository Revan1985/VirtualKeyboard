using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WW.WPF.VirtualKeyboard.Commands;
using WW.WPF.VirtualKeyboard.UserControls.Symbols;

namespace WW.WPF.VirtualKeyboard.ModelView
{
  public class KeyboardSymbolModelView : KeyboardModelView
  {
    public KeyboardSymbolModelView()
    {
    }

    private ICommand navigationCommand = null;

    public ICommand NavigationCommand
    {
      get
      {
        if (navigationCommand == null)
        {
          navigationCommand = new DelegateCommand<int>(ExecuteNavigationCommand);
        }

        return navigationCommand;
      }
    }

    private void ExecuteNavigationCommand(int value)
    {
      switch (value)
      {
        case 1:
          SelectedControl = new UCKeyboardSymbol1();
          break;
        case 2:
          SelectedControl = new UCKeyboardSymbol2();
          break;
        case 3:
          SelectedControl = new UCKeyboardSymbol3();
          break;
        case 4:
          SelectedControl = new UCKeyboardSymbol4();
          break;
      }
    }

  }
}
