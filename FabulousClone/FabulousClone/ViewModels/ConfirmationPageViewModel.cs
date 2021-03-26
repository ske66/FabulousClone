using FabulousClone.IServices;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace FabulousClone.ViewModels
{
    public class ConfirmationPageViewModel : ViewModelBase, IInitializeAsync
    {
        IQuestionsService _questionService;
        public ICommand NoCommand => new Command(async () => await NavigationService.NavigateAsync("/MultipleChoicePage"));
        public ICommand OkCommand => new Command(async () => await NavigationService.NavigateAsync("LetsDoItDialog"));

        public ConfirmationPageViewModel(INavigationService navigationService, IQuestionsService questionService) : base(navigationService)
        {
            _questionService = questionService;
        }

        public async Task InitializeAsync(INavigationParameters parameters)
        {
            await _questionService.Initialise();
            await _questionService.GetChoices();
        }
    }
}
