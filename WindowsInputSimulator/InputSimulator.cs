namespace WindowsInputSimulator
{
  public class InputSimulator : IInputSimulator
  {
    readonly IInputDeviceStateAdaptor inputDeviceState;
    readonly IKeyboardSimulator keyboard;
    readonly IMouseSimulator mouse;

    public IInputDeviceStateAdaptor InputDeviceState
    {
      get
      {
        return inputDeviceState;
      }
    }

    public IKeyboardSimulator Keyboard
    {
      get
      {
        return keyboard;
      }
    }

    public IMouseSimulator Mouse
    {
      get
      {
        return mouse;
      }
    }

    public InputSimulator()
    {
      inputDeviceState = new WindowsInputDeviceStateAdaptor();
      keyboard = new KeyboardSimulator(this);
      mouse = new MouseSimulator(this);
    }
    public InputSimulator(IKeyboardSimulator keyboard, IMouseSimulator mouse, IInputDeviceStateAdaptor inputDeviceState)
    {
      this.inputDeviceState = inputDeviceState;
      this.keyboard = keyboard;
      this.mouse = mouse;
    }
  }
}
