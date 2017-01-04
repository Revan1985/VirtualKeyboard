#pragma once

#include "Stdafx.h"

namespace NativeWrapper
{
	public ref struct WinUser abstract sealed
	{
		static UINT MapVirtualKeyEx(
				_In_ UINT uCode,
				_In_ MapVirtualKeyCode uMapType);
	};
}
