using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace ManagedNativeWrapper
{
  [StructLayout(LayoutKind.Explicit)]
  public struct MOUSEKEYBDHARDWAREINPUT
  {
    /// <summary>
    /// The <see cref="MOUSEINPUT"/> definition.
    /// </summary>
    [FieldOffset(0)]
    public MOUSEINPUT Mouse;

    /// <summary>
    /// The <see cref="KEYBDINPUT"/> definition.
    /// </summary>
    [FieldOffset(0)]
    public KEYBDINPUT Keyboard;

    /// <summary>
    /// The <see cref="HARDWAREINPUT"/> definition.
    /// </summary>
    [FieldOffset(0)]
    public HARDWAREINPUT Hardware;
  }
}
