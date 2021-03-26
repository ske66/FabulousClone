using FabulousClone.Enums;
using FabulousClone.IServices;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace FabulousClone.ViewModels
{
    public class GenderPageViewModel : ViewModelBase
    {
        IUserService _userService;
        List<GenderTemplate> _genderOptions;

        public List<GenderTemplate> GenderOptions 
        { 
            get => _genderOptions; 
            set => SetProperty(ref _genderOptions, value); 
        }

        public ICommand GenderTappedCommand => new Command<Gender>(async selectedGender => await NavigateToNextPageAsync(selectedGender));

        public GenderPageViewModel(INavigationService navigationService, IUserService userService) : base(navigationService)
        {
            _userService = userService;

            GenderOptions = new List<GenderTemplate> {
                new GenderTemplate(Gender.Woman, "Woman"),
                new GenderTemplate(Gender.Man, "Man"),
                new GenderTemplate(Gender.Nonbinary, "Non-binary")
            };
        }

        public async Task NavigateToNextPageAsync(Gender selectedGender)
        {
            _userService.User.Gender = selectedGender;
           
            await NavigationService.NavigateAsync("WakeUpPage");
        }
    }


    public class GenderTemplate
    {
        public GenderTemplate(Gender gender, string name)
        {
            Gender = gender;
            Name = name;
        }

        public Gender Gender { get; set; }
        public string Name { get; set; }
    }
}
