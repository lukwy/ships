using System.Windows.Input;

namespace Ships.Model.Interfaces
{
    public interface ITextCounter
    {
        string Text { get; set; }
        ICommand TextChangeCommand { get; set; }
    }
}
