using FabulousClone.IRepositories;
using FabulousClone.IServices;
using FabulousClone.Popups;
using FabulousClone.PopupViewModels;
using FabulousClone.Repositories;
using FabulousClone.Services;
using FabulousClone.ViewModels;
using FabulousClone.Views;
using Prism;
using Prism.Ioc;
using Prism.Plugin.Popups;
using System;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;

namespace FabulousClone
{
    public partial class App
    {
        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            //get user. if one is already in the database, load the main page along with the user's profile information. else go to the start page
            if (await Container.Resolve<UserService>().GetUser())
            {
                await NavigationService.NavigateAsync("NavigationPage/MainPage");
            }
            else
            {
                var result = await NavigationService.NavigateAsync("/NamePage");

                Console.WriteLine(result);
            }

        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();
            containerRegistry.RegisterPopupNavigationService();
            containerRegistry.RegisterPopupDialogService();
            containerRegistry.RegisterForNavigation<NavigationPage>();

            /* Views */
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<NamePage, NamePageViewModel>();
            containerRegistry.RegisterForNavigation<GenderPage, GenderPageViewModel>();
            containerRegistry.RegisterForNavigation<WakeUpPage, WakeUpPageViewModel>();
            containerRegistry.RegisterForNavigation<EmailPage, EmailPageViewModel>();
            containerRegistry.RegisterForNavigation<ConfirmationPage, ConfirmationPageViewModel>();
            containerRegistry.RegisterForNavigation<MultipleChoicePage, MultipleChoicePageViewModel>();


            /* Popups */
            containerRegistry.RegisterForNavigation<LetsDoItDialog, LetsDoItDialogViewModel>();


            /* Services */
            containerRegistry.RegisterSingleton<IUserService, UserService>();
            containerRegistry.RegisterSingleton<IQuestionsService, QuestionsService>();


            /* Repositories */
            containerRegistry.RegisterSingleton<IUserRepository, UserRepository>();
            containerRegistry.RegisterSingleton<IQuestionsRepository, QuestionsRepository>();


        }
    }
}
