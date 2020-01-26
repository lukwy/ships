using System.Collections.ObjectModel;

namespace Ships.Model.Interfaces
{
    public interface IGameSetter
    {
        ObservableCollection<IShip> ShipsData { get; }
        ITextCounter Message { get; set; }
        void GenerateMap();
        void StartGame();
    }
}
