using FabulousClone.IServices;
using FabulousClone.Models;
using Newtonsoft.Json;
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
    public class MultipleChoicePageViewModel : ViewModelBase, IInitializeAsync
    {
        IQuestionsService _questionsService;
        QuestionModel _question;
        List<ChoiceModel> _choices;

        public QuestionModel Question { get => _question; set => SetProperty(ref _question, value); }
        public List<ChoiceModel> Choices { get => _choices; set => SetProperty(ref _choices, value); }
        public ICommand ChoiceTappedCommand => new Command<int>(async selectedChoice => await NavigateToNextPageAsync(selectedChoice));

        public MultipleChoicePageViewModel(INavigationService navigationService, IQuestionsService questionsService) : base(navigationService)
        {
            _questionsService = questionsService;
        }

        public async Task NavigateToNextPageAsync(int choice)
        {
            await _questionsService.SetChoice(Question, choice);

            if (_questionsService.CurrentQuestionIndex == _questionsService.AllQuestions.Count())
                await NavigationService.NavigateAsync("/NavigationPage/MainPage");
            else
                await NavigationService.NavigateAsync("MultipleChoicePage");
        }

        public async Task InitializeAsync(INavigationParameters parameters)
        {
            Question = _questionsService.AllQuestions[_questionsService.CurrentQuestionIndex];
            Choices = JsonConvert.DeserializeObject<List<ChoiceModel>>(Question.Choices);
        }
    }
}
