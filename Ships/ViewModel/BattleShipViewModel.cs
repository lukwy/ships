using Ships.Model;
using System.Collections.ObjectModel;
using System.Linq;
using Ships.Commands;

namespace Ships.ViewModel
{
    internal class BattleShipViewModel
    {
        public BattleShipViewModel()
        {
            _ShipsData = new ObservableCollection<Ship>();
            Generate();
            StartCommand = new RelayCommand(StartGame, true);
            message = new TextCounter();
        }

        public RelayCommand StartCommand { get; set; }

        private ObservableCollection<Ship> _ShipsData;
        public ObservableCollection<Ship> ShipsData { get { return _ShipsData; } }

        private TextCounter message;

        public TextCounter Message
        {
            get { return message; }
            set { message = value; }
        }


        public void Generate()
        {
            _ShipsData.Clear();

            for (int i = 0; i < 400; i++)
            {
                var temp = new Ship();
                temp.SetWhite();
                _ShipsData.Add(temp);
            }
        }

        private void StartGame()
        {
            if (ShipsData.Any(s=>s.IsShip))
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
