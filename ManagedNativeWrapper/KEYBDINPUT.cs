using System;

namespace ManagedNativeWrapper
{
  public struct KEYBDINPUT
  {
    /// <summary>
    /// Specifies a virtual-key code. The code must be a value in the range 1 to 254. The Winuser.h header file provides macro definitions (VK_*) for each value. If the dwFlags member specifies KEYEVENTF_UNICODE, wVk must be 0. 
    /// </summary>
    public ushort KeyCode;

    /// <summary>
    /// Specifies a hardware scan code for the key. If dwFlags specifies KEYEVENTF_UNICODE, wScan specifies a Unicode character which is to be sent to the foreground application. 
    /// </summary>
    public ushort Scan;

    /// <summary>
    /// Specifies various aspects of a keystroke. This member can be certain combinations of the following values.
    /// KEYEVENTF_EXTENDEDKEY - If specified, the scan code was preceded by a prefix byte that has the value 0xE0 (224).
    /// KEYEVENTF_KEYUP - If specified, the key is being released. If not specified, the key is being pressed.
    /// KEYEVENTF_SCANCODE - If specified, wScan identifies the key and wVk is ignored. 
    /// KEYEVENTF_UNICODE - Windows 2000/XP: If specified, the system synthesizes a VK_PACKET keystroke. The wVk parameter must be zero. This flag can only be combined with the KEYEVENTF_KEYUP flag. For more information, see the Remarks section. 
    /// </summary>
    public uint Flags;

    /// <summary>
    /// Time stamp for the event, in milliseconds. If this parameter is zero, the system will provide its own time stamp. 
    /// </summary>
    public uint Time;

    /// <summary>
    /// Specifies an additional value associated with the keystroke. Use the GetMessageExtraInfo function to obtain this information. 
    /// </summary>
    public IntPtr ExtraInfo;
  }
}
