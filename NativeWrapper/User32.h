#pragma once

#include "Stdafx.h"

namespace NativeWrapper
{
	public ref struct User32 sealed abstract
	{
		static System::Int16 GetAsyncKeyState(int);
		static System::Int16 GetKeyState(int);

		static System::IntPtr GetMessageExtraInfo();
		static System::UInt32 SendInput(cli::array<INPUT>^);


		static bool ShowWindow(System::IntPtr, ShowWindowEnum);

		static int GetWindowLong(System::IntPtr, WindowLongEnum);
		static int SetWindowLong(System::IntPtr, WindowLongEnum, int);

		static System::IntPtr SetActiveWindow(System::IntPtr);

		static bool SetForegroundWindow(_In_ System::IntPtr hWnd);
		static bool SetWindowPos(_In_ System::IntPtr hWnd, bool topMost, _In_ int X, _In_ int Y, _In_ int cx, _In_ int cy, _In_ SetWindowPositionFlag uFlags);
	};
}
