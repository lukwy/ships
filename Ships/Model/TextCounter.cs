using Ships.Commands;
using System.ComponentModel;
using System.Windows.Input;

namespace Ships.Model
{
    class TextCounter : INotifyPropertyChanged
    {
        public ICommand TextChangeCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private string text;

        public string Text
        { 
            get{ return text; }
            set
            { 
                text = $"Ships to destroy: {value}";
                this.NotifyPropertyChanged("Text");
            }
        }

        public TextCounter()
        {
            TextChangeCommand = new RelayCommand(ChangeText);
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

        private void ChangeText()
        {
            Text = "";
        }
    }
}
