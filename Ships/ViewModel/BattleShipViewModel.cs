using System;
using Ships.Commands;
using Ships.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace Ships.ViewModel
{
    internal class BattleShipViewModel : INotifyPropertyChanged
    {
        public BattleShipViewModel()
        {
            _ShipsData = new ObservableCollection<Ship>();
        }

        

        /// <summary>
        /// Property changed Event 
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<Ship> _ShipsData;
        public ObservableCollection<Ship> ShipsData { get { return _ShipsData; } }

        public class SomeDataModel
        {
            public string Content { get; set; }

            public ICommand Command { get; set; }
        }

        //public <Ship> People { get; set; }
        public static ObservableCollection<Item> SalesPeriods
        {
            get
            {
                return new ObservableCollection<Item>()
                {
                    new Item() {Name = "6x6", Value = 6},
                    new Item() {Name = "12x12", Value = 12},
                    new Item() {Name = "20x20", Value = 20}
                };
            }
        }

        public class Item
        {
            public string Name { get; set; }
            public int Value { get; set; }
        }


        private Item selectedItem;

        public Item SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;

                _ShipsData.Clear();

                for (int i = 0; i < value.Value * value.Value; i++)
                {
                    var temp = new Ship();
                    temp.Color = Brushes.Lavender;
                    _ShipsData.Add(temp);
                }
            }
        }

        public bool CanUpdate
        {
            get;
            set;
        }

        public ICommand MyCommand
        {
            get;
            set;
        }

        private string _name;

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }


        private bool CanExecuteMyMethod(object parameter)
        {
            if (string.IsNullOrEmpty(Name))
            {
                return false;
            }
            else
            {
                if (Name != "")
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }

        private void ExecuteMyMethod(object parameter)
        {
            MessageBox.Show("Hello... " + Name);
        }
    }
}
