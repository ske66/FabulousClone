using FabulousClone.IServices;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FabulousClone.ViewModels
{
    public class NamePageViewModel : ViewModelBase
    {
        IUserService _userService;
        string _name;

        public string Name { get => _name; set => SetProperty(ref _name, value); }

        public DelegateCommand NextCommand { get; }

        public NamePageViewModel(INavigationService navigationService, IUserService userService) : base (navigationService) 
        {
            _userService = userService;
            NextCommand = new DelegateCommand(NavigateToNextPageAsync, CanExecute).ObservesProperty(() => Name);
        }

        private bool CanExecute()
        {
            return !string.IsNullOrEmpty(Name);
        }

        private async void NavigateToNextPageAsync()
        {
                _userService.User = new Models.UserModel();

                _userService.User.Name = Name;
                await NavigationService.NavigateAsync("GenderPage");

        }

    }
}
