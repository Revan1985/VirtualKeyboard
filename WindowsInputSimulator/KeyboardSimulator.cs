using ManagedNativeWrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WindowsInputSimulator
{
  public class KeyboardSimulator : IKeyboardSimulator
  {
    private readonly IInputSimulator inputSimulator;
    private readonly IInputMessageDispatcher inputMessageDispatcher;

    public KeyboardSimulator(IInputSimulator simulator) : this(simulator, new WindowsInputMessageDispatcher())
    {

    }
    internal KeyboardSimulator(IInputSimulator simulator, IInputMessageDispatcher dispatcher)
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

    public IMouseSimulator Mouse
    {
      get
      {
        return inputSimulator.Mouse;
      }
    }

    public IKeyboardSimulator KeyDown(VirtualKeyCode keyCode)
    {
      INPUT[] inputList = new InputBuilder().AddKeyDown(keyCode).ToArray();
      SendSimulatedInput(inputList);
      return this;
    }

    public IKeyboardSimulator KeyPress(params VirtualKeyCode[] keyCodes)
    {
      InputBuilder builder = new InputBuilder();
      KeysPress(builder, keyCodes);
      SendSimulatedInput(builder.ToArray());
      return this;
    }

    public IKeyboardSimulator KeyPress(VirtualKeyCode keyCode)
    {
      INPUT[] inputList = new InputBuilder().AddKeyPress(keyCode).ToArray();
      SendSimulatedInput(inputList);
      return this;
    }

    public IKeyboardSimulator KeyUp(VirtualKeyCode keyCode)
    {
      INPUT[] inputList = new InputBuilder().AddKeyUp(keyCode).ToArray();
      SendSimulatedInput(inputList);
      return this;
    }
    
    public IKeyboardSimulator UnicodeKeyPress(char unicode)
    {
      INPUT[] inputList = new InputBuilder().AddCharacter(unicode).ToArray();
      SendSimulatedInput(inputList);
      return this;
    }

    public IKeyboardSimulator UnicodeKeyPress(params char[] unicodes)
    {
      INPUT[] inputList = new InputBuilder().AddCharacters(unicodes).ToArray();
      SendSimulatedInput(inputList);
      return this;
    }
    
    public IKeyboardSimulator ModifiedKeyStroke(VirtualKeyCode modifierKeyCode, VirtualKeyCode keyCode)
    {
      return ModifiedKeyStroke(new[] { modifierKeyCode }, new[] { keyCode });
    }

    public IKeyboardSimulator ModifiedKeyStroke(VirtualKeyCode modifierKeyCode, IEnumerable<VirtualKeyCode> keyCodes)
    {
      return ModifiedKeyStroke(new[] { modifierKeyCode }, keyCodes);
    }

    public IKeyboardSimulator ModifiedKeyStroke(IEnumerable<VirtualKeyCode> modifierKeyCodes, VirtualKeyCode keyCode)
    {
      return ModifiedKeyStroke(modifierKeyCodes, new[] { keyCode });
    }

    public IKeyboardSimulator ModifiedKeyStroke(IEnumerable<VirtualKeyCode> modifierKeyCodes, IEnumerable<VirtualKeyCode> keyCodes)
    {
      InputBuilder builder = new InputBuilder();
      ModifiersDown(builder, modifierKeyCodes);
      KeysPress(builder, keyCodes);
      ModifiersUp(builder, modifierKeyCodes);

      SendSimulatedInput(builder.ToArray());
      return this;
    }

    public IKeyboardSimulator Sleep(TimeSpan timeout)
    {
      Thread.Sleep(timeout);
      return this;
    }

    public IKeyboardSimulator Sleep(int millsecondsTimeout)
    {
      Thread.Sleep(millsecondsTimeout);
      return this;
    }

    public IKeyboardSimulator TextEntry(char character)
    {
      var inputList = new InputBuilder().AddCharacter(character).ToArray();
      SendSimulatedInput(inputList);
      return this;
    }

    public IKeyboardSimulator TextEntry(string text)
    {
      if (text.Length > uint.MaxValue / 2)
        throw new ArgumentException(string.Format("The text parameter is too long. It must be less than {0} characters.", uint.MaxValue / 2), "text");
      var inputList = new InputBuilder().AddCharacters(text).ToArray();
      SendSimulatedInput(inputList);
      return this;
    }



    private void ModifiersDown(InputBuilder builder, IEnumerable<VirtualKeyCode> modifierKeyCodes)
    {
      if (modifierKeyCodes == null)
        return;
      foreach (var key in modifierKeyCodes)
        builder.AddKeyDown(key);
    }

    private void ModifiersUp(InputBuilder builder, IEnumerable<VirtualKeyCode> modifierKeyCodes)
    {
      if (modifierKeyCodes == null)
        return;

      // VirtualKeyCode up in reverse (I miss LINQ)
      var stack = new Stack<VirtualKeyCode>(modifierKeyCodes);
      while (stack.Count > 0)
        builder.AddKeyUp(stack.Pop());
    }

    private void KeysPress(InputBuilder builder, IEnumerable<VirtualKeyCode> keyCodes)
    {
      if (keyCodes == null)
        return;
      foreach (var key in keyCodes)
        builder.AddKeyPress(key);
    }

    private void SendSimulatedInput(INPUT[] inputList)
    {
      inputMessageDispatcher.DispatchInput(inputList);
    }

  }
}
