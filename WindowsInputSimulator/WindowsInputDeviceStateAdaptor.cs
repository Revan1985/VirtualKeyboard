
using ManagedNativeWrapper;

namespace WindowsInputSimulator
{
  public class WindowsInputDeviceStateAdaptor : IInputDeviceStateAdaptor
  {
    public bool IsHardwareKeyDown(VirtualKeyCode keyCode)
    {
      short data = User32.GetAsyncKeyState((ushort)keyCode);
      return data < 0;
    }

    public bool IsHardwareKeyUp(VirtualKeyCode keyCode)
    {
      return !IsHardwareKeyDown(keyCode);
    }

    public bool IsKeyDown(VirtualKeyCode keyCode)
    {
      short data = User32.GetKeyState((ushort)keyCode);
      return data < 0;
    }

    public bool IsKeyUp(VirtualKeyCode keyCode)
    {
      return !IsKeyDown(keyCode);
    }

    public bool IsTogglingKeyInEffect(VirtualKeyCode keyCode)
    {
      short data = User32.GetKeyState((ushort)keyCode);
      return (data & 0x01) == 0x01;
    }
  }
}
