using System;

namespace ManagedNativeWrapper
{
  [Flags()]
  public enum KeyEvent
  {
    None = 0x0,
    ExtendedKey = 0x0001,
    KeyUp = 0x0002,
    Unicode = 0x0004,
    Scancode = 0x0008,
  }
}
