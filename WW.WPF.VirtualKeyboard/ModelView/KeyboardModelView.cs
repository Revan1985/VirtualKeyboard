using ManagedNativeWrapper;
using System;
using System.Linq;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Timers;
using System.Windows.Controls;
using System.Windows.Input;
using WindowsInputSimulator;
using WW.WPF.VirtualKeyboard.Commands;

namespace WW.WPF.VirtualKeyboard.ModelView
{
  /// <summary>
  /// Keyboard Model View, used by all Usercontrols in the project.
  /// </summary>
  public class KeyboardModelView : INotifyPropertyChanged, IDisposable
  {
    InputSimulator simulator = new InputSimulator();

    #region INotifyPropertyChanged

    public event PropertyChangedEventHandler PropertyChanged;
    private void OnPropertyChanged(string propertyName)
    {
      if (PropertyChanged != null)
      {
        PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
      }
    }

    #endregion INotifyPropertyChanged

    /// <summary>
    /// Command used for unicode commands.
    /// Don't needs to convert from virtualkeycode to unicode.
    /// </summary>
    public ICommand UnicodeButtonClickedCommand
    {
      get
      {
        if (unicodeButtonClickedCommand == null)
        {
          unicodeButtonClickedCommand = new DelegateCommand<char[]>(ExecuteUnicodeButtonClickedCommand);
        }
        return unicodeButtonClickedCommand;
      }
    }

    /// <summary>
    /// Change the screen to show.
    /// </summary>
    public ICommand ChangeControlCommand
    {
      get
      {
        changeControlCommand = new DelegateCommand<string>(ExecuteChangeControlCommand);
        return changeControlCommand;
      }
    }

    /// <summary>
    /// Virtual Key Codes (Enter / Back / Space)
    /// </summary>
    public ICommand SpecialKeyCommand
    {
      get
      {
        specialKeyCommand = new DelegateCommand<VirtualKeyCode>(ExecuteSpecialKeyCommand);
        return specialKeyCommand;
      }
    }

    private ICommand unicodeButtonClickedCommand = null;
    private ICommand changeControlCommand = null;
    private ICommand specialKeyCommand = null;


    #region UnicodeButtonClickedCommand

    private void ExecuteUnicodeButtonClickedCommand(char[] value)
    {
      if (value != null)
      {
        // resize current value and copy from passed value array.
        Array.Resize(ref currentValues, value.Length);
        Array.Copy(value, currentValues, value.Length);

        // Must clean the last inserted char???
        bool CleanLastChar = true;

        // always reset the timer...
        // must be reset to one second at all also if the same button is clicked....
        timerTextReset.Stop();
        timerTextReset.Start();

        // check if the clicked button equals to previous one.
        if (currentValues.SequenceEqual(previousValues))
        {
          // same button as previous
          
          // reset the previous char if the length of values is more than 1, otherwise just keep it.
          CleanLastChar = !(currentValues.Length == 1);

          // increment index, if > than length, reset to 0.
          ++textIndex;
          textIndex %= currentValues.Length;
        }
        else
        {
          // new button
          // new one, reset index and do not execute back button click.
          CleanLastChar = false;
          textIndex = 0;
        }

        // clone current values to previous values.
        Array.Resize(ref previousValues, currentValues.Length);
        Array.Copy(currentValues, previousValues, currentValues.Length);

        // send keyboard data
        // 1 - selected char
        // 2 - shift button value
        // 3 - clean the previous written char
        SendKeyeboardData(currentValues[textIndex], shiftButtonClicked, CleanLastChar);
      }
    }

    #endregion UnicodeButtonClickedCommand

    #region ChangeControlCommand
    
    protected void ExecuteChangeControlCommand(string value)
    {
      // switch the selected screen.
      switch (value)
      {
        case "ABC":
          SelectedControl = new UserControls.UCKeyboardABC();                 // Keyboard control
          break;
        case "123":
          SelectedControl = new UserControls.UCKeyboard123();                 // Numeric Control
          break;
        case "SYM":
          SelectedControl = new UserControls.UCKeyboardSymbol();              // Symbols (all together)
          break;
        case "SYM1":
          SelectedControl = new UserControls.Symbols.UCKeyboardSymbol1();     // Symbols (page 1)
          break;
        case "SYM2":
          SelectedControl = new UserControls.Symbols.UCKeyboardSymbol2();     // Symbols (page 2)
          break;
        case "SYM3":
          SelectedControl = new UserControls.Symbols.UCKeyboardSymbol3();     // Symbols (page 3)
          break;
        case "SYM4":
          SelectedControl = new UserControls.Symbols.UCKeyboardSymbol4();     // Symbols (page 4)
          break;
      }
    }

    #endregion ChangeControlCommand

    #region SpecialKeyCommand

    private void ExecuteSpecialKeyCommand(VirtualKeyCode value)
    {
      switch (value)
      {
        //case VirtualKeyCode.Space:
        //  {
        //    char[] values = new char[1] { ' ' };
        //    ExecuteUnicodeButtonClickedCommand(values);
        //  }
        //  break;
        default:
          {
            // just send it, it's converted by windows...
            simulator.Keyboard.KeyDown(value);
          }
          break;
      }
    }

    #endregion SpecialKeyCommand

    private UserControl selectedcontrol = new UserControls.UCKeyboardABC();

    /// <summary>
    /// Control to be shown on MainWindow
    /// </summary>
    public UserControl SelectedControl
    {
      get
      {
        return selectedcontrol;
      }
      set
      {
        if (!ReferenceEquals(selectedcontrol, value))
        {
          selectedcontrol = value;
          OnPropertyChanged("SelectedControl");
        }
      }
    }
    
    private int textIndex = 0;

    private char[] currentValues = new char[1];
    private char[] previousValues = new char[1];

    private TimeSpan elapsedTimeSpan = TimeSpan.Zero;

    private bool shiftButtonClicked = false;

    private Stopwatch sw = new Stopwatch();
    private Timer timerTextReset = new Timer();

    /// <summary>
    /// The shift button has been clicked.
    /// </summary>
    public bool ShiftButtonClicked
    {
      get
      {
        return shiftButtonClicked;
      }
      set
      {
        if (!ReferenceEquals(shiftButtonClicked, value))
        {
          shiftButtonClicked = value;
          OnPropertyChanged("ShiftButtonClicked");
        }
      }
    }

    public KeyboardModelView()
    {
      // set the timer values, interval to 1sec and the 
      timerTextReset.Elapsed += NotifyTimerTextResetElapsed;
      timerTextReset.Interval = 1000;
    }

    /// <summary>
    /// This is called when the timer reach the 1s target.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void NotifyTimerTextResetElapsed(object sender, ElapsedEventArgs e)
    {
      //ok, stop the timer (enable = false)
      timerTextReset.Enabled = false;

      // Send the key command data
      // 1 - selected char
      // 2 - shift button value
      // 3 - always clean the previous written char
      SendKeyeboardData(currentValues[textIndex], shiftButtonClicked, true);

      // reset index and previous values, so this will be a new click (also if the clicked button is the same)
      previousValues = new char[1];
      textIndex = 0;
    }

    #region IDisposable

    ~KeyboardModelView()
    {
      Dispose(false);
    }
    public void Dispose()
    {
      Dispose(true);
      GC.SuppressFinalize(this);
    }
    protected virtual void Dispose(bool disposeManagedResources)
    {
      if (disposeManagedResources)
      {
        if (timerTextReset != null)
        {
          timerTextReset.Elapsed -= NotifyTimerTextResetElapsed;
          timerTextReset.Dispose();
          timerTextReset = null;
        }
      }
    }

    #endregion IDisposable


    /// <summary>
    /// Send the Data to Keyboard
    /// </summary>
    /// <param name="value">Charachter to print</param>
    /// <param name="shiftButtonClicked">Shift Button has been clicked</param>
    /// <param name="CleanLastChar">Last charachter must be cleaned</param>
    private void SendKeyeboardData(char value, bool shiftButtonClicked, bool CleanLastChar)
    {
      // if is a letter and shift is pressed, convert it.
      if (char.IsLetter(value) && shiftButtonClicked)
      {
        value = char.ToUpper(value);
      }

      // if must clean the last character, send the back command.
      if (CleanLastChar)
      {
        ExecuteSpecialKeyCommand(VirtualKeyCode.Back);
      }

      // ok, send the unicode value.
      simulator.Keyboard.UnicodeKeyPress(value);
    }
  }
}
