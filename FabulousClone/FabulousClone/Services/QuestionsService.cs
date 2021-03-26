using FabulousClone.IRepositories;
using FabulousClone.IServices;
using FabulousClone.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FabulousClone.Services
{
    public class QuestionsService : IQuestionsService
    {
        private readonly IQuestionsRepository _questionsRepository;
        public int CurrentQuestionIndex { get; set; } = 0;
        public List<QuestionModel> AllQuestions { get; set; }

        public QuestionsService(IQuestionsRepository questionsRepository)
        {
            _questionsRepository = questionsRepository;
        }

        public async Task Initialise() => await _questionsRepository.PopulateDatabase();
        public async Task GetChoices() => AllQuestions = await _questionsRepository.Get();
        public async Task SetChoice(QuestionModel question, int choice)
        {
            question.Choice = choice;
            await _questionsRepository.Update(question);
            CurrentQuestionIndex++;
        }
    }
}
