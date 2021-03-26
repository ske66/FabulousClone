using FabulousClone.ViewModels;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace FabulousClone.PopupViewModels
{
    public class LetsDoItDialogViewModel : ViewModelBase, IDialogAware
    {
        public DelegateCommand CloseCommand => new DelegateCommand(() => RequestClose?.Invoke(null));
        public ICommand LetsDoItCommand => new Command(async () => await NavigationService.NavigateAsync("/MultipleChoicePage"));


        public LetsDoItDialogViewModel(INavigationService navigationService) : base (navigationService)
        {
        }

        public event Action<IDialogParameters> RequestClose;

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
        }
    }
}
