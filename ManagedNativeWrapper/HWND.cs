using System;

namespace ManagedNativeWrapper
{
  public static class HWND
  {
    public static readonly IntPtr NoTopMost = new IntPtr(-2);
    public static readonly IntPtr TopMost = new IntPtr(-1);
    public static readonly IntPtr Top = new IntPtr(0);
    public static readonly IntPtr Bottom = new IntPtr(1);
  }
}
