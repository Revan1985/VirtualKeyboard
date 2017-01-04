using ManagedNativeWrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace WindowsInputSimulator
{
  internal class InputBuilder : IEnumerable<INPUT>
  {
    private readonly List<INPUT> inputs;

    public InputBuilder()
    {
      inputs = new List<INPUT>();
    }

    public INPUT[] ToArray()
    {
      return inputs.ToArray();
    }

    public IEnumerator<INPUT> GetEnumerator()
    {
      return inputs.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }

    public INPUT this[int index]
    {
      get
      {
        return inputs.ElementAt(index);
      }
    }

    public static bool IsExtendedKey(VirtualKeyCode keyCode)
    {
      switch (keyCode)
      {
        case VirtualKeyCode.LControl:
        case VirtualKeyCode.RControl:
        case VirtualKeyCode.Insert:
        case VirtualKeyCode.Delete:
        case VirtualKeyCode.Home:
        case VirtualKeyCode.End:
        case VirtualKeyCode.Prior:
        case VirtualKeyCode.Next:
        case VirtualKeyCode.Right:
        case VirtualKeyCode.Up:
        case VirtualKeyCode.Left:
        case VirtualKeyCode.Down:
        case VirtualKeyCode.NumLock:
        case VirtualKeyCode.Cancel:
        case VirtualKeyCode.Snapshot:
        case VirtualKeyCode.Divide:
          return true;
        default:
          return false;
      }
    }


    public InputBuilder AddKeyDown(VirtualKeyCode code)
    {
      INPUT down = new INPUT()
      {
        Type = (uint)InputType.Keyboard,
        Data = new MOUSEKEYBDHARDWAREINPUT()
        {
          Keyboard = new KEYBDINPUT()
          {
            KeyCode = (ushort)code,
            ExtraInfo = IntPtr.Zero,
            Flags = (uint)(IsExtendedKey(code) ? KeyEvent.ExtendedKey : KeyEvent.None),
            Time = 0U,
            Scan = 0,
          },
        }
      };

      inputs.Add(down);
      return this;
    }
    public InputBuilder AddKeyUp(VirtualKeyCode code)
    {
      INPUT down = new INPUT()
      {
        Type = (uint)InputType.Keyboard,
        Data = new MOUSEKEYBDHARDWAREINPUT()
        {
          Keyboard = new KEYBDINPUT()
          {
            KeyCode = (ushort)code,
            ExtraInfo = IntPtr.Zero,
            Flags = (uint)(IsExtendedKey(code) ? KeyEvent.ExtendedKey | KeyEvent.KeyUp : KeyEvent.KeyUp),
            Time = 0U,
            Scan = 0,
          }
        }
      };

      inputs.Add(down);
      return this;
    }

    public InputBuilder AddKeyPress(VirtualKeyCode code)
    {
      AddKeyDown(code);
      AddKeyUp(code);
      return this;
    }

    public InputBuilder AddCharacter(char character)
    {
      ushort scanCode = character;

      var down = new INPUT
      {
        Type = (uint)InputType.Keyboard,
        Data = new MOUSEKEYBDHARDWAREINPUT()
        {
          Keyboard = new KEYBDINPUT
          {
            KeyCode = 0,
            Scan = scanCode,
            Flags = (uint)KeyEvent.Unicode,
            Time = 0,
            ExtraInfo = IntPtr.Zero
          }
        }
      };

      var up = new INPUT
      {
        Type = (uint)InputType.Keyboard,
        Data = new MOUSEKEYBDHARDWAREINPUT()
        {
          Keyboard = new KEYBDINPUT
          {
            KeyCode = 0,
            Scan = scanCode,
            Flags = (uint)(KeyEvent.KeyUp | KeyEvent.Unicode),
            Time = 0,
            ExtraInfo = IntPtr.Zero
          }
        }
      };

      // Handle extended keys:
      // If the scan code is preceded by a prefix byte that has the value 0xE0 (224),
      // we need to include the KEYEVENTF_EXTENDEDKEY flag in the Flags property. 
      if ((scanCode & 0xFF00) == 0xE000)
      {
        down.Data.Keyboard.Flags |= (uint)KeyEvent.ExtendedKey;
        up.Data.Keyboard.Flags |= (uint)KeyEvent.ExtendedKey;
      }

      inputs.Add(down);
      inputs.Add(up);
      return this;
    }

    public InputBuilder AddCharacters(IEnumerable<char> characters)
    {
      foreach (var character in characters)
      {
        AddCharacter(character);
      }
      return this;
    }
    public InputBuilder AddCharacters(string characters)
    {
      return AddCharacters(characters.ToCharArray());
    }

    public InputBuilder AddRelativeMouseMovement(int x, int y)
    {
      var movement = new INPUT { Type = (uint)InputType.Mouse };
      movement.Data.Mouse.Flags = (uint)MouseEvent.Move;
      movement.Data.Mouse.X = x;
      movement.Data.Mouse.Y = y;

      inputs.Add(movement);

      return this;
    }

    public InputBuilder AddAbsoluteMouseMovement(int absoluteX, int absoluteY)
    {
      var movement = new INPUT { Type = (uint)InputType.Mouse };
      movement.Data.Mouse.Flags = (uint)(MouseEvent.Move | MouseEvent.Absolute);
      movement.Data.Mouse.X = absoluteX;
      movement.Data.Mouse.Y = absoluteY;

      inputs.Add(movement);

      return this;
    }

    public InputBuilder AddAbsoluteMouseMovementOnVirtualDesktop(int absoluteX, int absoluteY)
    {
      var movement = new INPUT { Type = (uint)InputType.Mouse };
      movement.Data.Mouse.Flags = (uint)(MouseEvent.Move | MouseEvent.Absolute | MouseEvent.VirtualDesk);
      movement.Data.Mouse.X = absoluteX;
      movement.Data.Mouse.Y = absoluteY;

      inputs.Add(movement);

      return this;
    }

    public InputBuilder AddMouseButtonDown(MouseButton button)
    {
      var buttonDown = new INPUT { Type = (uint)InputType.Mouse };
      buttonDown.Data.Mouse.Flags = (uint)ToMouseButtonDownEvent(button);

      inputs.Add(buttonDown);

      return this;
    }
    public InputBuilder AddMouseXButtonDown(int xButtonId)
    {
      var buttonDown = new INPUT { Type = (uint)InputType.Mouse };
      buttonDown.Data.Mouse.Flags = (uint)MouseEvent.XDown;
      buttonDown.Data.Mouse.MouseData = (uint)xButtonId;
      inputs.Add(buttonDown);

      return this;
    }

    public InputBuilder AddMouseButtonUp(MouseButton button)
    {
      var buttonUp = new INPUT { Type = (uint)InputType.Mouse };
      buttonUp.Data.Mouse.Flags = (uint)ToMouseButtonUpEvent(button);
      inputs.Add(buttonUp);

      return this;
    }

    public InputBuilder AddMouseXButtonUp(int xButtonId)
    {
      var buttonUp = new INPUT { Type = (uint)InputType.Mouse };
      buttonUp.Data.Mouse.Flags = (uint)MouseEvent.XUp;
      buttonUp.Data.Mouse.MouseData = (uint)xButtonId;
      inputs.Add(buttonUp);

      return this;
    }

    public InputBuilder AddMouseButtonClick(MouseButton button)
    {
      return AddMouseButtonDown(button).AddMouseButtonUp(button);
    }

    public InputBuilder AddMouseXButtonClick(int xButtonId)
    {
      return AddMouseXButtonDown(xButtonId).AddMouseXButtonUp(xButtonId);
    }

    public InputBuilder AddMouseButtonDoubleClick(MouseButton button)
    {
      return AddMouseButtonClick(button).AddMouseButtonClick(button);
    }

    public InputBuilder AddMouseXButtonDoubleClick(int xButtonId)
    {
      return AddMouseXButtonClick(xButtonId).AddMouseXButtonClick(xButtonId);
    }

    public InputBuilder AddMouseVerticalWheelScroll(int scrollAmount)
    {
      var scroll = new INPUT { Type = (uint)InputType.Mouse };
      scroll.Data.Mouse.Flags = (uint)MouseEvent.Wheel;
      scroll.Data.Mouse.MouseData = (uint)scrollAmount;

      inputs.Add(scroll);

      return this;
    }

    public InputBuilder AddMouseHorizontalWheelScroll(int scrollAmount)
    {
      var scroll = new INPUT { Type = (uint)InputType.Mouse };
      scroll.Data.Mouse.Flags = (uint)MouseEvent.HWheel;
      scroll.Data.Mouse.MouseData = (uint)scrollAmount;

      inputs.Add(scroll);

      return this;
    }

    private static MouseEvent ToMouseButtonDownEvent(MouseButton button)
    {
      switch (button)
      {
        case MouseButton.Left:
          return MouseEvent.LeftDown;

        case MouseButton.Middle:
          return MouseEvent.MiddleDown;

        case MouseButton.Right:
          return MouseEvent.RightDown;

        default:
          return MouseEvent.LeftDown;
      }
    }

    private static MouseEvent ToMouseButtonUpEvent(MouseButton button)
    {
      switch (button)
      {
        case MouseButton.Left:
          return MouseEvent.LeftUp;

        case MouseButton.Middle:
          return MouseEvent.MiddleUp;

        case MouseButton.Right:
          return MouseEvent.RightUp;

        default:
          return MouseEvent.LeftUp;
      }
    }
  }
}
