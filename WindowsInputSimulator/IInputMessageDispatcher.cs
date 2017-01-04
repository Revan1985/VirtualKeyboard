using ManagedNativeWrapper;

namespace WindowsInputSimulator
{
  public interface IInputMessageDispatcher
  {
    void DispatchInput(INPUT[] inputList);
  }
}
