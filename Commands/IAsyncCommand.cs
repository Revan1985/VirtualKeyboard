using System.Threading.Tasks;
using System.Windows.Input;

namespace WW.WPF.VirtualKeyboard.Commands
{
  public interface IAsyncCommand : IAsyncCommand<object>
  {  }
  public interface IAsyncCommand<in T>
  {
    Task ExecuteAsync(T obj);
    bool CanExecuteTask(T obj);
    ICommand Command
    {
      get;
    }
  }
}
