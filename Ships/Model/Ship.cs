using Ships.Commands;
using Ships.Model.Interfaces;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows.Media;

namespace Ships.Model
{
    public class Ship : INotifyPropertyChanged, IShip
    {
        public ICommand ButtonClick { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public bool IsShip { get; private set; }
        public bool IsGameStarted { get; set; }

        private Brush _Color;
        public Brush Color
        {
            get
            {
                return _Color;
            }
            set
            {
                _Color = value;
                NotifyPropertyChanged("Color");
            }
        }

        public Ship()
        {
            ButtonClick = new RelayCommand(ChangeColor, true);
        }

        private void ChangeColor()
        {
            if (IsGameStarted)
            {
                Color = IsShip ? Brushes.Chartreuse : Brushes.Red;
            }
            else
            {
                Color = Color == Brushes.White ? Brushes.Chartreuse : Brushes.White;
                IsShip = !IsShip;
            }
        }

        public void SetWhite()
        {
            Color = Brushes.White;
        }

        #region NotifyPropertyChanged

        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}
