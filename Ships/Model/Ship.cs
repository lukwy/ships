using Ships.Commands;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows.Media;

namespace Ships.Model
{
    class Ship : INotifyPropertyChanged
    {

        //Command binding property for Button Click
        public RelayCommand ButtonClick { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public Ship()
        {
            //Call the button command binding class to
            //register the button click event with the handler
            ButtonClick = new RelayCommand(ChangeColor);

            //Enable the button click event
            ButtonClick.IsEnabled = true;
        }


        /// <summary>
        /// Method to be called when property(value) is changed
        /// </summary>
        /// <param name="propertyName"></param>
        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        /// <summary>
        /// Actual method for display
        /// for button click event
        /// </summary>
        private void ChangeColor()
        {
            Color = Color == Brushes.Lavender ? Brushes.Chartreuse : Brushes.Lavender;
        }

        /// <summary>
        /// Property changed Event 
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        private string _Name;
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
                NotifyPropertyChanged("Name");
            }
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

        private int _Size;
        public int Size
        {
            get
            {
                //return _Size;
                return 10;
            }
            set
            {
                _Size = value;
                NotifyPropertyChanged("Size");
            }
        }
    }
}
