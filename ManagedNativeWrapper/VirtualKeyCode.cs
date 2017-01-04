using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ManagedNativeWrapper
{
  public enum VirtualKeyCode
  {

    /*
     * Virtual Keys, Standard Set
     */
    LeftButton = 0x01,
    RightButton = 0x02,
    Cancel = 0x03,
    MiddleButton = 0x04,


    XButton1 = 0x05,
    Xbutton2 = 0x06,


    /*
     * 0x07 : unassigned
     */

    Back = 0x08,
    Tab = 0x09,

    /*
     * 0x0A - 0x0B : reserved
     */

    Clear = 0x0C,
    Return = 0x0D,

    Shift = 0x10,
    Control = 0x11,
    Menu = 0x12,
    Pause = 0x13,
    Capital = 0x14,

    Kana = 0x15,
    Hanguel = 0x15,
    Hangul = 0x15,
    Junja = 0x17,
    final = 0x18,
    Hanja = 0x19,
    Kanji = 0x19,

    Escape = 0x1B,

    Convert = 0x1C,
    NonConvert = 0x1D,
    Accept = 0x1E,
    ModeChange = 0x1F,

    Space = 0x20,
    Prior = 0x21,
    Next = 0x22,
    End = 0x23,
    Home = 0x24,
    Left = 0x25,
    Up = 0x26,
    Right = 0x27,
    Down = 0x28,
    Select = 0x29,
    Print = 0x2A,
    Execute = 0x2B,
    Snapshot = 0x2C,
    Insert = 0x2D,
    Delete = 0x2E,
    Help = 0x2F,

    /*
     * VK_0 - VK_9 are the same as ASCII '0' - '9' (0x30 - 0x39)
     * 0x40 : unassigned
     * VK_A - VK_Z are the same as ASCII 'A' - 'Z' (0x41 - 0x5A)
     */

    Zero = 0x30,
    One = 0x31,
    Two = 0x32,
    Three = 0x33,
    Four = 0x34,
    Five = 0x35,
    Six = 0x36,
    Seven = 0x37,
    Eight = 0x38,
    Nine = 0x39,

    A = 0x41,
    B = 0x42,
    C = 0x43,
    D = 0x44,
    E = 0x45,
    F = 0x46,
    G = 0x47,
    H = 0x48,
    I = 0x49,
    J = 0x4A,
    K = 0x4B,
    L = 0x4C,
    M = 0x4D,
    N = 0x4E,
    O = 0x4F,
    P = 0x50,
    Q = 0x51,
    R = 0x52,
    S = 0x53,
    T = 0x54,
    U = 0x55,
    V = 0x56,
    W = 0x57,
    X = 0x58,
    Y = 0x59,
    Z = 0x5A,

    LWin = 0x5B,
    RWin = 0x5C,
    Apps = 0x5D,

    /*
     * 0x5E : reserved
     */

    Sleep = 0x5F,

    Numpad0 = 0x60,
    Numpad1 = 0x61,
    Numpad2 = 0x62,
    Numpad3 = 0x63,
    Numpad4 = 0x64,
    Numpad5 = 0x65,
    Numpad6 = 0x66,
    Numpad7 = 0x67,
    Numpad8 = 0x68,
    Numpad9 = 0x69,
    Multiply = 0x6A,
    Add = 0x6B,
    Separator = 0x6C,
    Subtract = 0x6D,
    Decimal = 0x6E,
    Divide = 0x6F,
    F1 = 0x70,
    F2 = 0x71,
    F3 = 0x72,
    F4 = 0x73,
    F5 = 0x74,
    F6 = 0x75,
    F7 = 0x76,
    F8 = 0x77,
    F9 = 0x78,
    F10 = 0x79,
    F11 = 0x7A,
    F12 = 0x7B,
    F13 = 0x7C,
    F14 = 0x7D,
    F15 = 0x7E,
    F16 = 0x7F,
    F17 = 0x80,
    F18 = 0x81,
    F19 = 0x82,
    F20 = 0x83,
    F21 = 0x84,
    F22 = 0x85,
    F23 = 0x86,
    F24 = 0x87,

    /*
     * 0x88 - 0x8F : unassigned
     */

    NumLock = 0x90,
    Scroll = 0x91,

    /*
     * NEC PC-9800 kbd definitions
     */
    OEM_NecEqual = 0x92,   // '=' key on numpad

    /*
     * Fujitsu/OASYS kbd definitions
     */
    OEM_FJ_Jisho = 0x92,   // 'Dictionary' key
    OEM_FJ_Masshou = 0x93,   // 'Unregister word' key
    OEM_FJ_Touroku = 0x94,   // 'Register word' key
    OEM_FJ_Loya = 0x95,   // 'Left OYAYUBI' key
    OEM_FJ_Roya = 0x96,   // 'Right OYAYUBI' key

    /*
     * 0x97 - 0x9F : unassigned
     */

    /*
     * VK_L* & VK_R* - left and right Alt, Ctrl and Shift virtual keys.
     * Used only as parameters to GetAsyncKeyState() and GetKeyState().
     * No other API or message will distinguish left and right keys in this way.
     */
    LShift = 0xA0,
    RShift = 0xA1,
    LControl = 0xA2,
    RControl = 0xA3,
    LMenu = 0xA4,
    RMenu = 0xA5,

    BrowserBack = 0xA6,
    BrowserForward = 0xA7,
    BrowserRefresh = 0xA8,
    BrowserStop = 0xA9,
    BrowserSearch = 0xAA,
    BrowserFavorites = 0xAB,
    BrowserHome = 0xAC,

    VolumeMute = 0xAD,
    VolumeDown = 0xAE,
    VolumeUp = 0xAF,
    MediaNextTrack = 0xB0,
    MediaPrevTrack = 0xB1,
    MediaStop = 0xB2,
    MediaPlayPause = 0xB3,
    LaunchMail = 0xB4,
    LaunchMediaSelect = 0xB5,
    LaunchApp1 = 0xB6,
    LaunchApp2 = 0xB7,

    /*
     * 0xB8 - 0xB9 : reserved
     */

    OEM_1 = 0xBA,   // ';:' for US
    OEM_Plus = 0xBB,   // '+' any country
    OEM_Comma = 0xBC,   // ',' any country
    OEM_Minus = 0xBD,   // '-' any country
    OEM_Period = 0xBE,   // '.' any country
    OEM_2 = 0xBF,   // '/?' for US
    OEM_3 = 0xC0,   // '`~' for US

    /*
     * 0xC1 - 0xD7 : reserved
     */

    /*
     * 0xD8 - 0xDA : unassigned
     */

    OEM_4 = 0xDB,  //  '[{' for US
    OEM_5 = 0xDC,  //  '\|' for US
    OEM_6 = 0xDD,  //  ']}' for US
    OEM_7 = 0xDE,  //  ''"' for US
    OEM_8 = 0xDF,

    /*
     * 0xE0 : reserved
     */

    /*
     * Various extended or enhanced keyboards
     */
    OEM_AX = 0xE1,  //  'AX' key on Japanese AX kbd
    OEM_102 = 0xE2, //  "<>" or "\|" on RT 102-key kbd.
    ICO_Help = 0xE3,  //  Help key on ICO
    ICO_00 = 0xE4,  //  00 key on ICO


    ProcessKey = 0xE5,

    ICO_CLear = 0xE6,


    Packet = 0xE7,

    /*
     * 0xE8 : unassigned
     */

    /*
     * Nokia/Ericsson definitions
     */
    OEM_Reset = 0xE9,
    OEM_Jump = 0xEA,
    OEM_PA1 = 0xEB,
    OEM_PA2 = 0xEC,
    OEM_PA3 = 0xED,
    OEM_WSControl = 0xEE,
    OEM_Cusel = 0xEF,
    OEM_Attn = 0xF0,
    OEM_Finish = 0xF1,
    OEM_Copy = 0xF2,
    OEM_Auto = 0xF3,
    OEM_ENLW = 0xF4,
    OEM_BackTab = 0xF5,

    Attn = 0xF6,
    CRSel = 0xF7,
    Exsel = 0xF8,
    Ereof = 0xF9,
    Play = 0xFA,
    Zoom = 0xFB,
    NoName = 0xFC,
    PA1 = 0xFD,
    OEM_Clear = 0xFE,

    /*
     * 0xFF : reserved
     */
  }
}
