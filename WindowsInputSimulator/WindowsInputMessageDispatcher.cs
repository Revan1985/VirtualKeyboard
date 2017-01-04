using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManagedNativeWrapper;
using System.Runtime.InteropServices;

namespace WindowsInputSimulator
{
  public class WindowsInputMessageDispatcher : IInputMessageDispatcher
  {
    public void DispatchInput(INPUT[] inputList)
    {
      if (inputList == null)
      {
        throw new ArgumentNullException("inputs");
      }

      if (inputList.Length == 0)
      {
        throw new ArgumentException("The input array was empty", "inputs");
      }
      uint successful = User32.SendInput((uint)inputList.Length, inputList, Marshal.SizeOf(typeof(INPUT)));

      if (successful != inputList.Length)
      {
        throw new Exception("Some simulated input commands were not sent successfully. The most common reason for this happening are the security features of Windows including User Interface Privacy Isolation (UIPI). Your application can only send commands to applications of the same or lower elevation. Similarly certain commands are restricted to Accessibility/UIAutomation applications. Refer to the project home page and the code samples for more information.");
      }
    }
  }
}
