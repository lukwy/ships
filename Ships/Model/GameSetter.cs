using Ships.Commands;
using Ships.Model.Interfaces;
using System.Collections.ObjectModel;
using System.Linq;

namespace Ships.Model
{
    public class GameSetter : IGameSetter
    {
        public RelayCommand StartCommand { get; set; }

        public ITextCounter Message { get; set; }

        private const int MapSize = 400; 

        private ObservableCollection<IShip> _ShipsData;
        public ObservableCollection<IShip> ShipsData {
            get
            {
                if (_ShipsData == null)
                {
                    _ShipsData = new ObservableCollection<IShip>();
                }

                return _ShipsData;
            }
        }

        public GameSetter(ITextCounter textCounter)
        {
            Message = textCounter;
           
            StartCommand = new RelayCommand(StartGame, true); 
        }

        public void GenerateMap()
        {
            ShipsData.Clear();

            for (int i = 0; i < MapSize; i++)
            {
                var temp = new Ship();
                temp.SetWhite();
                ShipsData.Add(temp);
            }
        }

        public void StartGame()
        {
            if (ShipsData.Any(s => s.IsShip))
            {
                foreach (var ship in ShipsData)
                {
                    ship.IsGameStarted = true;
                    ship.SetWhite();
                }
                Message.Text = ShipsData.Where(s => s.IsShip).Count().ToString();
            }
        }
    }
}
