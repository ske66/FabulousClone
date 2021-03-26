using FabulousClone.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FabulousClone.IServices
{
    public interface IQuestionsService
    {
        int CurrentQuestionIndex { get; set; }
        List<QuestionModel> AllQuestions { get; set; }
        Task Initialise();
        Task GetChoices();
        Task SetChoice(QuestionModel question, int choice);
    }
}
