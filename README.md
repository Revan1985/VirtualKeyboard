# VirtualKeyboard

A simple keyboard designed for Handheld devices.
Designed to work on a 480x640 or 240x320 device resolution.
Use a compact layout, derived from "Android Physical keyboard" layout (not qwerty)

Use C# 4.0 / WPF / WinAPI.

Use Win32 API to lost focus every time is gained and a button clicked, so that the previous focus is restored.
Try to use also a Cli wrapper for the native part.


This Keyboard does not need to be integrated in an appication, it's a standalone version that uses win api to stay always on top of other windows (since i didn't found a valid way to do this in wpf)
