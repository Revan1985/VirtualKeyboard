using ManagedNativeWrapper;
using System;
using System.Threading;

namespace WindowsInputSimulator
{
  public class MouseSimulator : IMouseSimulator
  {
    private const int MouseWheelClickSize = 120;

    private readonly IInputSimulator inputSimulator;
    private readonly IInputMessageDispatcher inputMessageDispatcher;

    public MouseSimulator(IInputSimulator simulator) : this(simulator, new WindowsInputMessageDispatcher())
    {

    }
    internal MouseSimulator(IInputSimulator simulator, IInputMessageDispatcher dispatcher)
    {

      if (simulator == null)
      {
        throw new NullReferenceException("simulator");
      }

      if (dispatcher == null)
      {
        throw new InvalidOperationException(
                    string.Format("The {0} cannot operate with a null {1}. Please provide a valid {1} instance to use for dispatching {2} messages.",
                    typeof(KeyboardSimulator).Name, typeof(IInputMessageDispatcher).Name, string.Empty));// typeof(INPUT).Name));
      }

      inputSimulator = simulator;
      inputMessageDispatcher = dispatcher;
    }

    public IKeyboardSimulator Keyboard
    {
      get
      {
        return inputSimulator.Keyboard;
      }
    }

    public IMouseSimulator HorizontalScroll(int scrollAmountInClicks)
    {
      var inputList = new InputBuilder().AddMouseHorizontalWheelScroll(scrollAmountInClicks * MouseWheelClickSize).ToArray();
      SendSimulatedInput(inputList);
      return this;
    }

    public IMouseSimulator LeftButtonClick()
    {
      var inputList = new InputBuilder().AddMouseButtonClick(MouseButton.Left).ToArray();
      SendSimulatedInput(inputList);
      return this;
    }

    public IMouseSimulator LeftButtonDoubleClick()
    {
      var inputList = new InputBuilder().AddMouseButtonDoubleClick(MouseButton.Left).ToArray();
      SendSimulatedInput(inputList);
      return this;
    }

    public IMouseSimulator LeftButtonDown()
    {
      var inputList = new InputBuilder().AddMouseButtonDown(MouseButton.Left).ToArray();
      SendSimulatedInput(inputList);
      return this;
    }

    public IMouseSimulator LeftButtonUp()
    {
      var inputList = new InputBuilder().AddMouseButtonUp(MouseButton.Left).ToArray();
      SendSimulatedInput(inputList);
      return this;
    }

    public IMouseSimulator MoveMouseBy(int pixelDeltaX, int pixelDeltaY)
    {
      INPUT[] inputList = new InputBuilder().AddRelativeMouseMovement(pixelDeltaX, pixelDeltaY).ToArray();
      SendSimulatedInput(inputList);
      return this;
    }

    public IMouseSimulator MoveMouseTo(double absoluteX, double absoluteY)
    {
      INPUT[] inputList = new InputBuilder().AddAbsoluteMouseMovement((int)Math.Truncate(absoluteX), (int)Math.Truncate(absoluteY)).ToArray();
      SendSimulatedInput(inputList);
      return this;
    }

    public IMouseSimulator MoveMouseToPositionOnVirtualDesktop(double absoluteX, double absoluteY)
    {
      INPUT[] inputList = new InputBuilder().AddAbsoluteMouseMovementOnVirtualDesktop((int)Math.Truncate(absoluteX), (int)Math.Truncate(absoluteY)).ToArray();
      SendSimulatedInput(inputList);
      return this;
    }

    public IMouseSimulator RightButtonClick()
    {
      var inputList = new InputBuilder().AddMouseButtonClick(MouseButton.Right).ToArray();
      SendSimulatedInput(inputList);
      return this;
    }

    public IMouseSimulator RightButtonDoubleClick()
    {
      var inputList = new InputBuilder().AddMouseButtonDoubleClick(MouseButton.Right).ToArray();
      SendSimulatedInput(inputList);
      return this;
    }

    public IMouseSimulator RightButtonDown()
    {
      var inputList = new InputBuilder().AddMouseButtonDown(MouseButton.Right).ToArray();
      SendSimulatedInput(inputList);
      return this;
    }

    public IMouseSimulator RightButtonUp()
    {
      var inputList = new InputBuilder().AddMouseButtonUp(MouseButton.Right).ToArray();
      SendSimulatedInput(inputList);
      return this;
    }

    public IMouseSimulator Sleep(TimeSpan timeout)
    {
      Thread.Sleep(timeout);
      return this;
    }

    public IMouseSimulator Sleep(int millsecondsTimeout)
    {
      Thread.Sleep(millsecondsTimeout);
      return this;
    }

    public IMouseSimulator VerticalScroll(int scrollAmountInClicks)
    {
      var inputList = new InputBuilder().AddMouseVerticalWheelScroll(scrollAmountInClicks * MouseWheelClickSize).ToArray();
      SendSimulatedInput(inputList);
      return this;
    }

    public IMouseSimulator XButtonClick(int buttonId)
    {
      var inputList = new InputBuilder().AddMouseXButtonClick(buttonId).ToArray();
      SendSimulatedInput(inputList);
      return this;
    }

    public IMouseSimulator XButtonDoubleClick(int buttonId)
    {
      var inputList = new InputBuilder().AddMouseXButtonDoubleClick(buttonId).ToArray();
      SendSimulatedInput(inputList);
      return this;
    }

    public IMouseSimulator XButtonDown(int buttonId)
    {
      var inputList = new InputBuilder().AddMouseXButtonDown(buttonId).ToArray();
      SendSimulatedInput(inputList);
      return this;
    }

    public IMouseSimulator XButtonUp(int buttonId)
    {
      var inputList = new InputBuilder().AddMouseXButtonUp(buttonId).ToArray();
      SendSimulatedInput(inputList);
      return this;
    }



    private void SendSimulatedInput(INPUT[] inputList)
    {
      inputMessageDispatcher.DispatchInput(inputList);
    }
  }
}
