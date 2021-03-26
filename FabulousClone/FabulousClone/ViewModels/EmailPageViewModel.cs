using FabulousClone.IServices;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace FabulousClone.ViewModels
{
    public class EmailPageViewModel : ViewModelBase
    {
        IUserService _userService;

        string _email;
        bool _isNotRecievingEmails;

        public string Email { get => _email; set => SetProperty(ref _email, value); }
        public bool IsNotRecievingEmails { get => _isNotRecievingEmails; set => SetProperty(ref _isNotRecievingEmails, value); }

        public DelegateCommand NextCommand { get; }

        public EmailPageViewModel(INavigationService navigationService, IUserService userService) : base(navigationService)
        {
            _userService = userService;
            
            NextCommand = new DelegateCommand(NavigateToNextPageAsync, CanExecute).ObservesProperty(() => Email);
        }

        private bool CanExecute()
        {
            // Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            // Match match = regex.Match(Email);

            //return match.Success;

            return !string.IsNullOrEmpty(Email);
        }

        private async void NavigateToNextPageAsync()
        {
            _userService.User.Email = Email;
            _userService.User.SendEmails = !IsNotRecievingEmails;
            await NavigationService.NavigateAsync("ConfirmationPage");

        }
    }
}
