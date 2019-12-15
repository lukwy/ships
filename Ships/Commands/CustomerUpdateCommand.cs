using Ships.ViewModel;
using System;
using System.Windows.Input;

namespace Ships.Commands
{
    internal class CustomerUpdateCommand : ICommand
    {        
        private BattleShipViewModel _ViewModel;

        public CustomerUpdateCommand(BattleShipViewModel viewModel)
        {
            _ViewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return _ViewModel.CanUpdate;
        }

        public void Execute(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}
