using Ships.Model;
using Ships.Model.Interfaces;

namespace Ships.ViewModel
{
    internal class BattleShipViewModel
    {
        public IGameSetter GameSetter { get; private set; }
        public BattleShipViewModel()
        {
            ITextCounter message = new TextCounter();
            GameSetter = new GameSetter(message);
        }

        public void Init()
        {
            GameSetter.GenerateMap();
        }
    }
}
