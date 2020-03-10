using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using UnitechMobileApp.ViewModels;

namespace UnitechMobileApp.Models.Commands
{
    class AuthCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private AuthViewModel vm;

        public AuthCommand(AuthViewModel vm)
        {
            this.vm = vm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (CanExecute(parameter))
                vm.Auth();
        }
    }
}
