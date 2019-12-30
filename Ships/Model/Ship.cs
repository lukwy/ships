using Ships.Commands;
using System.ComponentModel;
using System.Windows.Media;

namespace Ships.Model
{
    public class Ship : INotifyPropertyChanged
    {
        public RelayCommand ButtonClick { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public Ship()
        {
            ButtonClick = new RelayCommand(ChangeColor);
            ButtonClick.IsEnabled = true;
        }

        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void ChangeColor()
        {
            if(IsGameStarted)
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

        public bool IsShip { get; private set; }
        public bool IsGameStarted { get; set; }
    }
}
