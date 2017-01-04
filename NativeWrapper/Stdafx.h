// stdafx.h : include file for standard system include files,
// or project specific include files that are used frequently,
// but are changed infrequently

#pragma once


#define WIN32_LEAN_AND_MEAN
#include <Windows.h>

namespace NativeWrapper
{
	using namespace System::Runtime::InteropServices;

	public enum class VirtualKeyCode
	{
		None = 0x0,
		/*
		* Virtual Keys, Standard Set
		*/
		LButton = VK_LBUTTON,
		RButton = VK_RBUTTON,
		Cancel = VK_CANCEL,
		MButton = VK_MBUTTON,    /* NOT contiguous with L & RBUTTON */

#if(_WIN32_WINNT >= 0x0500)
		XButton1 = VK_XBUTTON1,    /* NOT contiguous with L & RBUTTON */
		XButton2 = VK_XBUTTON2,    /* NOT contiguous with L & RBUTTON */
#endif /* _WIN32_WINNT >= 0x0500 */

								   /*
								   * 0x07 : unassigned
								   */

		Back = VK_BACK,
		Tab = VK_TAB,

		/*
		* 0x0A - 0x0B : reserved
		*/

		Clear = VK_CLEAR,
		Return = VK_RETURN,

		Shift = VK_SHIFT,
		Control = VK_CONTROL,
		Menu = VK_MENU,
		Pause = VK_PAUSE,
		Capital = VK_CAPITAL,

		Kana = VK_KANA,
		Hangeul = VK_HANGEUL,  /* old name - should be here for compatibility */
		Hangul = VK_HANGUL,
		Junja = VK_JUNJA,
		Final = VK_FINAL,
		Hanja = VK_HANJA,
		Kanji = VK_KANJI,

		Escap = VK_ESCAPE,

		Convert = VK_CONVERT,
		NonConvert = VK_NONCONVERT,
		Accept = VK_ACCEPT,
		ModeChange = VK_MODECHANGE,

		Space = VK_SPACE,
		Prior = VK_PRIOR,
		Next = VK_NEXT,
		End = VK_END,
		Home = VK_HOME,
		Left = VK_LEFT,
		Up = VK_UP,
		Right = VK_RIGHT,
		Down = VK_DOWN,
		Select = VK_SELECT,
		Print = VK_PRINT,
		Execute = VK_EXECUTE,
		Snapshot = VK_SNAPSHOT,
		Insert = VK_INSERT,
		Delete = VK_DELETE,
		Help = VK_HELP,


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
		/*
		* VK_0 - VK_9 are the same as ASCII '0' - '9' (0x30 - 0x39)
		* 0x40 : unassigned
		* VK_A - VK_Z are the same as ASCII 'A' - 'Z' (0x41 - 0x5A)
		*/

		LWin = VK_LWIN,
		RWin = VK_RWIN,
		Apps = VK_APPS,

		/*
		* 0x5E : reserved
		*/

		Sleep = VK_SLEEP,

		Numpad0 = VK_NUMPAD0,
		Numpad1 = VK_NUMPAD1,
		Numpad2 = VK_NUMPAD2,
		Numpad3 = VK_NUMPAD3,
		Numpad4 = VK_NUMPAD4,
		Numpad5 = VK_NUMPAD5,
		Numpad6 = VK_NUMPAD6,
		Numpad7 = VK_NUMPAD7,
		Numpad8 = VK_NUMPAD8,
		Numpad9 = VK_NUMPAD9,
		Multiply = VK_MULTIPLY,
		Add = VK_ADD,
		Separator = VK_SEPARATOR,
		Subtract = VK_SUBTRACT,
		Decimal = VK_DECIMAL,
		Divide = VK_DIVIDE,
		F1 = VK_F1,
		F2 = VK_F2,
		F3 = VK_F3,
		F4 = VK_F4,
		F5 = VK_F5,
		F6 = VK_F6,
		F7 = VK_F7,
		F8 = VK_F8,
		F9 = VK_F9,
		F10 = VK_F10,
		F11 = VK_F11,
		F12 = VK_F12,
		F13 = VK_F13,
		F14 = VK_F14,
		F15 = VK_F15,
		F16 = VK_F16,
		F17 = VK_F17,
		F18 = VK_F18,
		F19 = VK_F19,
		F20 = VK_F20,
		F21 = VK_F21,
		F22 = VK_F22,
		F23 = VK_F23,
		F24 = VK_F24,

		/*
		* 0x88 - 0x8F : unassigned
		*/

		NumLock = VK_NUMLOCK,
		Scroll = VK_SCROLL,

		/*
		* NEC PC-9800 kbd definitions
		*/
		OEM_NecEqual = VK_OEM_NEC_EQUAL,   // '=' key on numpad

										   /*
										   * Fujitsu/OASYS kbd definitions
										   */
		OEM_FJ_Jisho = VK_OEM_FJ_JISHO,  // 'Dictionary' key
		OEM_FJ_Masshou = VK_OEM_FJ_MASSHOU,  // 'Unregister word' key
		OEM_FJ_Touroku = VK_OEM_FJ_TOUROKU,  // 'Register word' key
		OEM_FJ_Loya = VK_OEM_FJ_LOYA,  // 'Left OYAYUBI' key
		OEM_FJ_Roya = VK_OEM_FJ_ROYA,  // 'Right OYAYUBI' key

									   /*
									   * 0x97 - 0x9F : unassigned
									   */

									   /*
									   * VK_L* & VK_R* - left and right Alt, Ctrl and Shift virtual keys.
									   * Used only as parameters to GetAsyncKeyState() and GetKeyState().
									   * No other API or message will distinguish left and right keys in this way.
									   */
		LShift = VK_LSHIFT,
		RShift = VK_RSHIFT,
		LControl = VK_LCONTROL,
		RControl = VK_RCONTROL,
		LMenu = VK_LMENU,
		RMenu = VK_RMENU,

#if(_WIN32_WINNT >= 0x0500)
		BrowserBack =		VK_BROWSER_BACK,
		BrowserForward =	VK_BROWSER_FORWARD,
		BrowserRefresh =	VK_BROWSER_REFRESH,
		BrowserStop =		VK_BROWSER_STOP,
		BrowserSearch =		VK_BROWSER_SEARCH,
		BrowserFavorites =	VK_BROWSER_FAVORITES,
		BrowserHome =		VK_BROWSER_HOME,

		VolumeMute =		VK_VOLUME_MUTE,
		VolumeDown =		VK_VOLUME_DOWN,
		VolumeUp =			VK_VOLUME_UP,
		MediaNextTrack =	 VK_MEDIA_NEXT_TRACK,
		MediaPrevTrack =	VK_MEDIA_PREV_TRACK,
		MediaStop =			VK_MEDIA_STOP,
		MediaPlayPause =	VK_MEDIA_PLAY_PAUSE,
		LaunchMail =		VK_LAUNCH_MAIL,
		LaunchMediaSelect = VK_LAUNCH_MEDIA_SELECT,
		LaunchApp1 =		VK_LAUNCH_APP1,
		LaunchApp2 =		VK_LAUNCH_APP2,

#endif /* _WIN32_WINNT >= 0x0500 */

		/*
		* 0xB8 - 0xB9 : reserved
		*/

		OEM_1 =		VK_OEM_1,			// ';:' for US
		OEM_Plus =	VK_OEM_PLUS,		// '+' any country
		OEM_Comma = VK_OEM_COMMA,	// ',' any country
		OEM_Minus = VK_OEM_MINUS,	// '-' any country
		OEM_Period = VK_OEM_PERIOD,	// '.' any country
		OEM_2 =		VK_OEM_2,			// '/?' for US
		OEM_3 =		VK_OEM_3,			// '`~' for US

						   /*
						   * 0xC1 - 0xD7 : reserved
						   */

						   /*
						   * 0xD8 - 0xDA : unassigned
						   */

		OEM_4 = VK_OEM_4,			//  '[{' for US
		OEM_5 = VK_OEM_5,			//  '\|' for US
		OEM_6 = VK_OEM_6,			//  ']}' for US
		OEM_7 = VK_OEM_7,			//  ''"' for US
		OEM_8 = VK_OEM_8,

		/*
		* 0xE0 : reserved
		*/

		/*
		* Various extended or enhanced keyboards
		*/
		OEM_AX =	VK_OEM_AX,  //  'AX' key on Japanese AX kbd
		OEM_102 =	VK_OEM_102,  //  "<>" or "\|" on RT 102-key kbd.
		ICO_Help =	VK_ICO_HELP,  //  Help key on ICO
		ICO_00 =	VK_ICO_00,  //  00 key on ICO

#if(WINVER >= 0x0400)
		ProcessKey = VK_PROCESSKEY,
#endif /* WINVER >= 0x0400 */

		ICO_CLear = VK_ICO_CLEAR,


#if(_WIN32_WINNT >= 0x0500)
		Packet = VK_PACKET,
#endif /* _WIN32_WINNT >= 0x0500 */

		/*
		* 0xE8 : unassigned
		*/

		/*
		* Nokia/Ericsson definitions
		*/
		OEM_Reset =			VK_OEM_RESET,
		OEM_Jump =		VK_OEM_JUMP,
		OEM_PA1 =		VK_OEM_PA1,
		OEM_PA2 =		VK_OEM_PA2,
		OEM_PA3 =		VK_OEM_PA3,
		OEM_WSControl = VK_OEM_WSCTRL,
		OEM_Cusel =		VK_OEM_CUSEL,
		OEM_Attn =		VK_OEM_ATTN,
		OEM_Finish =	VK_OEM_FINISH,
		OEM_Copy =		VK_OEM_COPY,
		OEM_Auto =		VK_OEM_AUTO,
		OEM_ENLW =		VK_OEM_ENLW,
		OEM_BackTab =	VK_OEM_BACKTAB,

		Attn =		VK_ATTN,
		CRSel =			VK_CRSEL,
		Exsel =			VK_EXSEL,
		Ereof =			VK_EREOF,
		Play =		VK_PLAY,
		Zoom =		VK_ZOOM,
		NoName =		VK_NONAME,
		PA1 =		 VK_PA1,
		OEM_Clear = VK_OEM_CLEAR,

		/*
		* 0xFF : reserved
		*/



	};

	public enum class MapVirtualKeyCode
	{
#if(WINVER >= 0x0400)
		VirtualKeyCodeToVirtualScanCode = MAPVK_VK_TO_VSC,
		VirtualScanCodeToVirtualKeyCode = MAPVK_VSC_TO_VK,
		VirtualKeyCodeToCharachter = MAPVK_VK_TO_CHAR,
		VirtualScanCodeToVirtualKeyCode_Extended = MAPVK_VSC_TO_VK_EX,
#endif /* WINVER >= 0x0400 */
#if(WINVER >= 0x0600)		
		VirtualKeyCodeToVirtualScanCode_extended = MAPVK_VK_TO_VSC_EX,
#endif /* WINVER >= 0x0600 */
	};

	public enum class InputType
	{
		Mouse = INPUT_MOUSE,
		Keyboard = INPUT_KEYBOARD,
		Hardware = INPUT_HARDWARE,
	};

	[System::FlagsAttribute()]
	public enum class KeyEvent
	{
		None = 0x0,
		ExtendedKey = KEYEVENTF_EXTENDEDKEY,
		KeyUp = KEYEVENTF_KEYUP,
		Unicode = KEYEVENTF_UNICODE,
		Scancode = KEYEVENTF_SCANCODE,
	};

	[System::FlagsAttribute()]
	public enum class MouseEvent
	{
		None = 0x0,
		Move = MOUSEEVENTF_MOVE,
		LeftDown = MOUSEEVENTF_LEFTDOWN,
		LeftUp = MOUSEEVENTF_LEFTUP,
		RightDown = MOUSEEVENTF_RIGHTDOWN,
		RightUp = MOUSEEVENTF_RIGHTUP,
		MiddleDown = MOUSEEVENTF_MIDDLEDOWN,
		MiddleUp = MOUSEEVENTF_MIDDLEUP,
		XDown = MOUSEEVENTF_XDOWN,
		XUp = MOUSEEVENTF_XUP,
		Wheel = MOUSEEVENTF_WHEEL,
#if (_WIN32_WINNT >= 0x0600)
		HWheel = MOUSEEVENTF_HWHEEL,
#endif
#if(WINVER >= 0x0600)
		MoveNoCoalesce = MOUSEEVENTF_MOVE_NOCOALESCE,
#endif /* WINVER >= 0x0600 */
		VirtualDesk = MOUSEEVENTF_VIRTUALDESK,
		Absolute = MOUSEEVENTF_ABSOLUTE,
	};

	public value struct KEYBDINPUT
	{
		/// <summary>
		/// Specifies a virtual-key code. The code must be a value in the range 1 to 254. The Winuser.h header file provides macro definitions (VK_*) for each value. If the dwFlags member specifies KEYEVENTF_UNICODE, wVk must be 0. 
		/// </summary>
		VirtualKeyCode KeyCode;

		/// <summary>
		/// Specifies a hardware scan code for the key. If dwFlags specifies KEYEVENTF_UNICODE, wScan specifies a Unicode character which is to be sent to the foreground application. 
		/// </summary>
		System::UInt16 Scan;

		/// <summary>
		/// Specifies various aspects of a keystroke. This member can be certain combinations of the following values.
		/// KEYEVENTF_EXTENDEDKEY - If specified, the scan code was preceded by a prefix byte that has the value 0xE0 (224).
		/// KEYEVENTF_KEYUP - If specified, the key is being released. If not specified, the key is being pressed.
		/// KEYEVENTF_SCANCODE - If specified, wScan identifies the key and wVk is ignored. 
		/// KEYEVENTF_UNICODE - Windows 2000/XP: If specified, the system synthesizes a VK_PACKET keystroke. The wVk parameter must be zero. This flag can only be combined with the KEYEVENTF_KEYUP flag. For more information, see the Remarks section. 
		/// </summary>
		KeyEvent Flags;

		/// <summary>
		/// Time stamp for the event, in milliseconds. If this parameter is zero, the system will provide its own time stamp. 
		/// </summary>
		System::UInt32 Time;

		/// <summary>
		/// Specifies an additional value associated with the keystroke. Use the GetMessageExtraInfo function to obtain this information. 
		/// </summary>
		System::IntPtr ExtraInfo;

	internal:
		//::KEYBDINPUT ToNative();
	};

	public value struct MOUSEINPUT
	{
		/// <summary>
		/// Specifies the absolute position of the mouse, or the amount of motion since the last mouse event was generated, depending on the value of the dwFlags member. Absolute data is specified as the x coordinate of the mouse; relative data is specified as the number of pixels moved. 
		/// </summary>
		System::Int32 X;

		/// <summary>
		/// Specifies the absolute position of the mouse, or the amount of motion since the last mouse event was generated, depending on the value of the dwFlags member. Absolute data is specified as the y coordinate of the mouse; relative data is specified as the number of pixels moved. 
		/// </summary>
		System::Int32 Y;

		/// <summary>
		/// If dwFlags contains MOUSEEVENTF_WHEEL, then mouseData specifies the amount of wheel movement. A positive value indicates that the wheel was rotated forward, away from the user; a negative value indicates that the wheel was rotated backward, toward the user. One wheel click is defined as WHEEL_DELTA, which is 120. 
		/// Windows Vista: If dwFlags contains MOUSEEVENTF_HWHEEL, then dwData specifies the amount of wheel movement. A positive value indicates that the wheel was rotated to the right; a negative value indicates that the wheel was rotated to the left. One wheel click is defined as WHEEL_DELTA, which is 120.
		/// Windows 2000/XP: IfdwFlags does not contain MOUSEEVENTF_WHEEL, MOUSEEVENTF_XDOWN, or MOUSEEVENTF_XUP, then mouseData should be zero. 
		/// If dwFlags contains MOUSEEVENTF_XDOWN or MOUSEEVENTF_XUP, then mouseData specifies which X buttons were pressed or released. This value may be any combination of the following flags. 
		/// </summary>
		System::UInt32 MouseData;

		/// <summary>
		/// A set of bit flags that specify various aspects of mouse motion and button clicks. The bits in this member can be any reasonable combination of the following values. 
		/// The bit flags that specify mouse button status are set to indicate changes in status, not ongoing conditions. For example, if the left mouse button is pressed and held down, MOUSEEVENTF_LEFTDOWN is set when the left button is first pressed, but not for subsequent motions. Similarly, MOUSEEVENTF_LEFTUP is set only when the button is first released. 
		/// You cannot specify both the MOUSEEVENTF_WHEEL flag and either MOUSEEVENTF_XDOWN or MOUSEEVENTF_XUP flags simultaneously in the dwFlags parameter, because they both require use of the mouseData field. 
		/// </summary>
		MouseEvent Flags;

		/// <summary>
		/// Time stamp for the event, in milliseconds. If this parameter is 0, the system will provide its own time stamp. 
		/// </summary>
		System::UInt32 Time;

		/// <summary>
		/// Specifies an additional value associated with the mouse event. An application calls GetMessageExtraInfo to obtain this extra information. 
		/// </summary>
		System::IntPtr ExtraInfo;

	internal:
		//::MOUSEINPUT ToNative();
	};
	public value struct HARDWAREINPUT
	{
		System::UInt32	Msg;
		System::UInt16	ParamL;
		System::UInt16	ParamH;
	};

	public value struct INPUT
	{
		InputType Type;

		KEYBDINPUT Keyboard;
		MOUSEINPUT Mouse;
		HARDWAREINPUT Hardware;

	internal:
		::INPUT ToNative()
		{
			::INPUT data;
			data.type = (DWORD)Type;
			switch (Type)
			{
			case InputType::Keyboard:
			{
				data.ki.dwExtraInfo = (ULONG_PTR)Keyboard.ExtraInfo.ToInt64();
				data.ki.dwFlags = (DWORD)Keyboard.Flags;
				data.ki.time = (DWORD)Keyboard.Time;
				data.ki.wScan = (WORD)Keyboard.Scan;
				data.ki.wVk = (WORD)Keyboard.KeyCode;
			}
			break;
			case InputType::Mouse:
			{
				data.mi.dwExtraInfo = (ULONG_PTR)Mouse.ExtraInfo.ToInt64();
				data.mi.dwFlags = (DWORD)Mouse.Flags;
				data.mi.dx = (LONG)Mouse.X;
				data.mi.dy = (LONG)Mouse.Y;
				data.mi.mouseData = (DWORD)Mouse.MouseData;
				data.mi.time = (DWORD)Mouse.Time;
			}
			break;
			case InputType::Hardware:
			{
			}
			break;
			}

			return data;
		}
	};

	public enum class ShowWindowEnum
	{
		Hide = SW_HIDE,
		ShowNormal = SW_SHOWNORMAL,
		Normal = SW_NORMAL,
		ShowMinimized = SW_SHOWMINIMIZED,
		ShowMaximized = SW_SHOWMAXIMIZED,
		Maximize = SW_MAXIMIZE,
		ShowNoActivate = SW_SHOWNOACTIVATE,
		Show = SW_SHOW,
		Minimize = SW_MINIMIZE,
		ShowMinNoActive = SW_SHOWMINNOACTIVE,
		SnowNA = SW_SHOWNA,
		Restore = SW_RESTORE,
		ShowDefault = SW_SHOWDEFAULT,
		ForceMinimize = SW_FORCEMINIMIZE,
		Max = SW_MAX,
	};

	public enum class WindowLongEnum
	{
		WndProd = GWL_WNDPROC,
		HInstance = GWL_HINSTANCE,
		HwndParent = GWL_HWNDPARENT,
		Style = GWL_STYLE,
		ExStyle = GWL_EXSTYLE,
		UserData = GWL_USERDATA,
		ID = GWL_ID,
	};

	[System::FlagsAttribute()]
	public enum class ExtendedWindowStyles
	{

		/*
		* Extended Window Styles
		*/
		DialogModelFrame = WS_EX_DLGMODALFRAME,
		NoParentNotify = WS_EX_NOPARENTNOTIFY,
		TopMost = WS_EX_TOPMOST,
		AcceptFiles = WS_EX_ACCEPTFILES,
		Transparent = WS_EX_TRANSPARENT,
#if(WINVER >= 0x0400)
		MDIChild = WS_EX_MDICHILD,
		ToolWindow = WS_EX_TOOLWINDOW,
		WindowEdge = WS_EX_WINDOWEDGE,
		ClientEdge = WS_EX_CLIENTEDGE,
		ContextHelp = WS_EX_CONTEXTHELP,

#endif /* WINVER >= 0x0400 */	
#if(WINVER >= 0x0400)

		Right = WS_EX_RIGHT,
		Left = WS_EX_LEFT,
		RightToLeftReading = WS_EX_RTLREADING,
		LeftToRightReading = WS_EX_LTRREADING,
		LeftScrollbar = WS_EX_LEFTSCROLLBAR,
		RightScrollbar = WS_EX_RIGHTSCROLLBAR,

		ControlParent = WS_EX_CONTROLPARENT,
		StaticEdge = WS_EX_STATICEDGE,
		AppWindow = WS_EX_APPWINDOW,


		OverLappedWindow = WS_EX_OVERLAPPEDWINDOW,
		PaletteWindow = WS_EX_PALETTEWINDOW,

#endif /* WINVER >= 0x0400 */

#if(_WIN32_WINNT >= 0x0500)
		Layered = WS_EX_LAYERED,

#endif /* _WIN32_WINNT >= 0x0500 */


#if(WINVER >= 0x0500)
		NoInheritLayout = WS_EX_NOINHERITLAYOUT,// Disable inheritence of mirroring by children
#endif /* WINVER >= 0x0500 */

#if(WINVER >= 0x0602)
		NoRedirectionBitmap = WS_EX_NOREDIRECTIONBITMAP,
#endif /* WINVER >= 0x0602 */

#if(WINVER >= 0x0500)
		LayoutRightToLeft = WS_EX_LAYOUTRTL,// Right to left mirroring
#endif /* WINVER >= 0x0500 */

#if(_WIN32_WINNT >= 0x0501)
		Composited = WS_EX_COMPOSITED,
#endif /* _WIN32_WINNT >= 0x0501 */
#if(_WIN32_WINNT >= 0x0500)
		NoActivate = WS_EX_NOACTIVATE,
#endif /* _WIN32_WINNT >= 0x0500 */
	};

	/*
	* WM_MOUSEACTIVATE Return Codes
	*/
	public enum class MouseActivate
	{
		Activate = MA_ACTIVATE,
		ActivateAndEat = MA_ACTIVATEANDEAT,
		NoActivate = MA_NOACTIVATE,
		NoActivateAndEat = MA_NOACTIVATEANDEAT,
	};

	/*
	* Window Messages
	*/
	public enum class WindowMessages
	{
		Null = WM_NULL,
		Create = WM_CREATE,
		Destroy = WM_DESTROY,
		Move = WM_MOVE,
		Size = WM_SIZE,

		Activate = WM_ACTIVATE,

		SetFocus = WM_SETFOCUS,
		KillFocus = WM_KILLFOCUS,
		Enable = WM_ENABLE,
		SetRedraw = WM_SETREDRAW,
		SetText = WM_SETTEXT,
		GetText = WM_GETTEXT,
		GetTextLength = WM_GETTEXTLENGTH,
		Paint = WM_PAINT,
		Close = WM_CLOSE,
#ifndef _WIN32_WCE
		QueryEndSession = WM_QUERYENDSESSION,
		QueryOpen = WM_QUERYOPEN,
		EndSession = WM_ENDSESSION,
#endif
		Quit = WM_QUIT,
		EraseBackground = WM_ERASEBKGND,
		SysColorChange = WM_SYSCOLORCHANGE,
		ShowWindow = WM_SHOWWINDOW,
		WinINIChange = WM_WININICHANGE,
#if(WINVER >= 0x0400)
		SettingChange = WM_SETTINGCHANGE,
#endif /* WINVER >= 0x0400 */


		DevModeChange = WM_DEVMODECHANGE,
		ActivateApp = WM_ACTIVATEAPP,
		FontChange = WM_FONTCHANGE,
		TimeChange = WM_TIMECHANGE,
		CancelMode = WM_CANCELMODE,
		SetCursos = WM_SETCURSOR,
		MouseActivate = WM_MOUSEACTIVATE,
		ChildActivate = WM_CHILDACTIVATE,
		QueueSync = WM_QUEUESYNC,

		GetMinMaxInfo = WM_GETMINMAXINFO,
	};

	public enum class WindowActivateEnum
	{
		Inactive = WA_INACTIVE,
		Active = WA_ACTIVE,
		ClickActive = WA_CLICKACTIVE,
	};




	/*
	* SetWindowPos Flags
	*/

	[System::FlagsAttribute()]
	public enum class SetWindowPositionFlag
	{
		NoSize = SWP_NOSIZE,
		NoMove = SWP_NOMOVE,
		NoZOrder = SWP_NOZORDER,
		NoRedraw = SWP_NOREDRAW,
		NoActivate = SWP_NOACTIVATE,
		FrameChanged = SWP_FRAMECHANGED,  /* The frame changed: send WM_NCCALCSIZE */
		ShowWindow = SWP_SHOWWINDOW,
		HideWindow = SWP_HIDEWINDOW,
		nocopyBits = SWP_NOCOPYBITS,
		NoOwnerZOrdering = SWP_NOOWNERZORDER,  /* Don't do owner Z ordering */
		NoSendChanging = SWP_NOSENDCHANGING,  /* Don't send WM_WINDOWPOSCHANGING */

		DrawFrame = SWP_DRAWFRAME,
		NoReposition = SWP_NOREPOSITION,

#if(WINVER >= 0x0400)
		DeferErase = SWP_DEFERERASE,
		AsyncWindowPos = SWP_ASYNCWINDOWPOS,
#endif /* WINVER >= 0x0400 */
	};
}