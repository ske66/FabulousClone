using FabulousClone.IServices;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace FabulousClone.ViewModels
{
    public class WakeUpPageViewModel : ViewModelBase
    {
        IUserService _userService;
        List<TimeTemplate> _wakeUpTimes;
        bool _timePickerSelected;
        bool _timeSelected;
        TimeSpan _time;
        Color _timePickerBackground;
        Color _timePickerTextColor;

        public List<TimeTemplate> WakeUpTimes{ get => _wakeUpTimes; set => SetProperty(ref _wakeUpTimes, value); }
        public bool TimePickerSelected
        { 
            get => _timePickerSelected;
            set
            {
                SetProperty(ref _timePickerSelected, value);
                TimePickerBackground = _timePickerSelected ? (Color) Application.Current.Resources["Secondary"] : Color.Transparent;
                TimePickerTextColor = _timePickerSelected ? Color.Black : Color.White;
            }
        }
        public bool TimeSelected { get => _timeSelected; set => SetProperty(ref _timeSelected, value); }
        public Color TimePickerBackground { get => _timePickerBackground; set => SetProperty(ref _timePickerBackground, value); }
        public Color TimePickerTextColor { get => _timePickerTextColor; set => SetProperty(ref _timePickerTextColor, value); }
        public TimeSpan Time 
        { 
            get => _time;
            set
            {
                SetProperty(ref _time, value);
                SetActiveTimePickerAsync();
            }
        }

        public ICommand TimeTappedCommand => new Command<TimeTemplate>(time => SetActiveTimeAsync(time));

        public ICommand NextCommand => new DelegateCommand(async () => await NavigateToNextPageAsync(), CanExecute).ObservesProperty(() => TimeSelected).ObservesProperty(() => TimePickerSelected);

        public WakeUpPageViewModel(INavigationService navigationService, IUserService userService) : base(navigationService)
        {
            _userService = userService;

            TimePickerBackground = Color.Transparent;
            TimePickerTextColor = Color.White;

            WakeUpTimes = new List<TimeTemplate>
            {
                new TimeTemplate(new TimeSpan(7,0,0), "07:00"),
                new TimeTemplate(new TimeSpan(8,0,0), "08:00"),
                new TimeTemplate(new TimeSpan(9,0,0), "09:00"),
            };
        }

        private void SetActiveTimeAsync(TimeTemplate time)
        {
            TimeSelected = true;
            TimePickerSelected = false;

            foreach (var t in WakeUpTimes.Where(t => t.Value != time.Value))
                t.IsSelected = false;
            
            time.IsSelected = true;
        }

        private void SetActiveTimePickerAsync()
        {
            WakeUpTimes.Select(c => { c.IsSelected = false; return c; }).ToList();

            TimePickerSelected = true;
            TimeSelected = false;
        }

        private bool CanExecute() => TimePickerSelected || TimeSelected;
        

        private async Task NavigateToNextPageAsync()
        {
            _userService.User.WakeUpTime = TimeSelected ? WakeUpTimes.FirstOrDefault(t => t.IsSelected).Value : Time;

            await NavigationService.NavigateAsync("EmailPage");
        }
    }

    public class TimeTemplate : BindableBase
    {
        public TimeTemplate(TimeSpan value, string time)
        {
            Value = value;
            Time = time;
            Background = Color.Transparent;
            TextColor = Color.White;
        }

        bool _isSelected;
        Color _background;
        Color _textColor;

        public bool IsSelected 
        { 
            get => _isSelected; 
            set
            {
                SetProperty(ref _isSelected, value);
                Background = _isSelected ? (Color) Application.Current.Resources["Secondary"] : Color.Transparent;
                TextColor = _isSelected ? Color.Black : Color.White;
            }
        }
        public TimeSpan Value { get; set; }
        public string Time { get; set; }
        public Color Background { get => _background; set => SetProperty(ref _background, value); }
        public Color TextColor { get => _textColor; set => SetProperty(ref _textColor, value); }
    }
}
