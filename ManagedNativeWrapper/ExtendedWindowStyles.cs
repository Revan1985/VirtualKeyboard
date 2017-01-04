using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ManagedNativeWrapper
{
  public enum ExtendedWindowStyles : long
  {
    /*
		* Extended Window Styles
		*/
    DialogModelFrame = 0x00000001L,
    NoParentNotify = 0x00000004L,
    TopMost = 0x00000008L,
    AcceptFiles = 0x00000010L,
    Transparent = 0x00000020L,
    MDIChild = 0x00000040L,
    ToolWindow = 0x00000080L,
    WindowEdge = 0x00000100L,
    ClientEdge = 0x00000200L,
    ContextHelp = 0x00000400L,
    Right = 0x00001000L,
    Left = 0x00000000L,
    RightToLeftReading = 0x00002000L,
    LeftToRightReading = 0x00000000L,
    LeftScrollbar = 0x00004000L,
    RightScrollbar = 0x00000000L,

    ControlParent = 0x00010000L,
    StaticEdge = 0x00020000L,
    AppWindow = 0x00040000L,


    OverLappedWindow = WindowEdge | ClientEdge,
    PaletteWindow = WindowEdge | ToolWindow | TopMost,

    Layered = 0x00080000,

    NoInheritLayout = 0x00100000L,// Disable inheritence of mirroring by children
    NoRedirectionBitmap = 0x00200000L,
    LayoutRightToLeft = 0x00400000L,// Right to left mirroring
    Composited = 0x02000000L,
    NoActivate = 0x08000000L,
  }
}
