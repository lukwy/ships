using Ships.Commands;
using Ships.Model.Interfaces;
using System.ComponentModel;
using System.Windows.Input;

namespace Ships.Model
{
    public class TextCounter : INotifyPropertyChanged, ITextCounter
    {
        public ICommand TextChangeCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private string _Text;

        public string Text
        { 
            get{ return _Text; }
            set
            { 
                _Text = $"Ships to destroy: {value}";
                NotifyPropertyChanged("Text");
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
