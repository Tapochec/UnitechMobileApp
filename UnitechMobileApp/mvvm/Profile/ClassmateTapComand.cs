using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using UnitechMobileApp.Model;

namespace UnitechMobileApp.mvvm.Profile
{
    class ClassmateTapComand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var sender = (CircleImage)parameter;
            viewModel.selectedClassMate = Workspace.ActiveUser.GetUserData(sender.Tag.ToString());
            viewModel.selectedClassMate.UserAvatar = Workspace.ActiveUser.GetUserAvatar(sender.Tag.ToString(), sender.AvatarPath.ToString());
            viewModel.OnLoginedUser = viewModel.activeUser.IsUserSame(viewModel.selectedClassMate);
            viewModel.ClassMates = Workspace.ActiveUser.GetUserClassMates(sender.Tag.ToString());
            viewModel.Refresh();
        }

        private ProfilePageViewModel viewModel; 

        public ClassmateTapComand(ProfilePageViewModel vm)
        {
            viewModel = vm;
        }
    }
}
