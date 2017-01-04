using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ManagedNativeWrapper
{
  public enum WindowMessages
  {
    Null = 0x0000,
    Create = 0x0001,
    Destroy = 0x0002,
    Move = 0x0003,
    Size = 0x0005,

    Activate = 0x0006,

    SetFocus = 0x0007,
    KillFocus = 0x0008,
    Enable = 0x000A,
    SetRedraw = 0x000B,
    SetText = 0x000C,
    GetText = 0x000D,
    GetTextLength = 0x000E,
    Paint = 0x000F,
    Close = 0x0010,

    QueryEndSession = 0x0011,
    QueryOpen = 0x0013,
    EndSession = 0x0016,

    Quit = 0x0012,
    EraseBackground = 0x0014,
    SysColorChange = 0x0015,
    ShowWindow = 0x0018,
    WinINIChange = 0x001A,

    SettingChange = WinINIChange,


    DevModeChange = 0x001B,
    ActivateApp = 0x001C,
    FontChange = 0x001D,
    TimeChange = 0x001E,
    CancelMode = 0x001F,
    SetCursos = 0x0020,
    MouseActivate = 0x0021,
    ChildActivate = 0x0022,
    QueueSync = 0x0023,

    GetMinMaxInfo = 0x0024,
  }
}
