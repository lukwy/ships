using System.Windows.Input;
using System.Windows.Media;

namespace Ships.Model.Interfaces
{
    public interface IShip
    {
        Brush Color { get; set; }
        bool IsShip { get; }
        bool IsGameStarted { get; set; }
        ICommand ButtonClick { get; set; }
        void SetWhite();
    }
}
