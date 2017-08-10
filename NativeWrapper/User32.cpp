#include "Stdafx.h"
#include "User32.h"

#pragma comment(lib, "User32.lib")

namespace NativeWrapper
{
	System::Int16 User32::GetAsyncKeyState(int vKey)
	{
		return ::GetAsyncKeyState(vKey);
	}
	System::Int16 User32::GetKeyState(int vVirtKey)
	{
		return ::GetKeyState(vVirtKey);
	}

	System::IntPtr User32::GetMessageExtraInfo()
	{
		LPARAM data = ::GetMessageExtraInfo();
		return System::IntPtr(data);
	}
	System::UInt32 User32::SendInput(cli::array<INPUT>^ inputs)
	{
		UINT data = 0U;

		::LPINPUT pInputs = new ::INPUT[inputs->Length];
		for (__int32 index = 0; index < inputs->Length; ++index)
		{
			pInputs[index] = inputs[index].ToNative();
		}

		data = ::SendInput((UINT)inputs->Length, pInputs, sizeof(::INPUT));

		if (pInputs != nullptr) { delete[] pInputs; }

		return data;
	}

	bool User32::ShowWindow(System::IntPtr hWnd, ShowWindowEnum nCmdShow)
	{
		BOOL data = ::ShowWindow((HWND)hWnd.ToPointer(), (int)nCmdShow);
		return data == TRUE;
	}


	int User32::GetWindowLong(System::IntPtr hWnd, WindowLongEnum nIndex)
	{
		LONG value = ::GetWindowLong((HWND)hWnd.ToPointer(), (int)nIndex);
		return value;
	}
	int User32::SetWindowLong(System::IntPtr hWnd, WindowLongEnum nIndex, int dwNewLong)
	{
		LONG value = ::SetWindowLong((HWND)hWnd.ToPointer(), (int)nIndex, dwNewLong);
		return value;
	}

	System::IntPtr User32::SetActiveWindow(System::IntPtr hWnd)
	{
		HWND activated = ::SetActiveWindow((HWND)hWnd.ToPointer());
		return System::IntPtr(activated);
	}

	bool User32::SetForegroundWindow(_In_ System::IntPtr hWnd)
	{
		BOOL foreground = ::SetForegroundWindow((HWND)hWnd.ToPointer());
		return foreground == TRUE;
	}

	bool User32::SetWindowPos(_In_ System::IntPtr hWnd, bool topMost, _In_ int X, _In_ int Y, _In_ int cx, _In_ int cy, _In_ SetWindowPositionFlag uFlags)
	{
		HWND hWndInsertAfter = topMost ? HWND_TOPMOST : HWND_BOTTOM;

		BOOL value = ::SetWindowPos((HWND)hWnd.ToPointer(), hWndInsertAfter, X, Y, cx, cy, (UINT)uFlags);
		return value == TRUE;
	}
}
