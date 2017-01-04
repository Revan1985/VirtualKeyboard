#include "Stdafx.h"
#include "WinUser.h"

namespace NativeWrapper
{
	UINT WinUser::MapVirtualKeyEx(
		_In_ UINT uCode,
		_In_ MapVirtualKeyCode uMapType)
	{
		UINT code = ::MapVirtualKey(uCode, (UINT)uMapType);
		return code;
	}
}