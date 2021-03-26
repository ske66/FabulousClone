using FabulousClone.IRepositories;
using FabulousClone.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FabulousClone.Repositories
{
    public class QuestionsRepository : Repository<QuestionModel>, IQuestionsRepository
    {

        public QuestionsRepository()
        {
        }        

        public async Task PopulateDatabase()
        {
            await Connection.DeleteAllAsync<QuestionModel>();

            await Insert(new QuestionModel
            {
                Id = 1,
                Title = "Why have you come to this app, or why has it come to you, now?",
                Choices = JsonConvert.SerializeObject(
                    new List<ChoiceModel>
                    {
                        new ChoiceModel(1, "Hope"),
                        new ChoiceModel(2, "Despair"),
                        new ChoiceModel(3, "Curiosity"),
                        new ChoiceModel(4, "Research")
                    })
            });

            await Insert(new QuestionModel
            {
                Id = 2,
                Title = "How often do you focus on the past or future",
                Choices = JsonConvert.SerializeObject(
                    new List<ChoiceModel>
                    {
                        new ChoiceModel(1, "Never - I live in the present"),
                        new ChoiceModel(2, "Some of the time"),
                        new ChoiceModel(3, "Most of the time"),
                        new ChoiceModel(4, "All of the time")
                    })
             });

            await Insert(new QuestionModel
            {
                Id = 3,
                Title = "Who gets in the way of what you want",
                Choices = JsonConvert.SerializeObject(
                    new List<ChoiceModel>
                    {
                        new ChoiceModel(1, "My family"),
                        new ChoiceModel(2, "My friends"),
                        new ChoiceModel(3, "My boss or coworkers"),
                        new ChoiceModel(4, "Myself")
                    })
            });

            await Insert(new QuestionModel
            {
                Id = 4,
                Title = "How satisfied are you with your current fitness level?",
                Choices = JsonConvert.SerializeObject(
                    new List<ChoiceModel>
                    {
                        new ChoiceModel(1, "Completely - I am fit and health"),
                        new ChoiceModel(2, "Somewhat - I'd like to see some improvement"),
                        new ChoiceModel(3, "Not at all - I'd like to see a major change"),
                    })
            });

            await Insert(new QuestionModel
            {
                Id = 5,
                Title = "What single change would improve your life right now?",
                Choices = JsonConvert.SerializeObject(
                    new List<ChoiceModel>
                    {
                        new ChoiceModel(1, "More energy"),
                        new ChoiceModel(2, "More strength"),
                        new ChoiceModel(3, "More focus"),                        
                        new ChoiceModel(4, "More calm"),
                    })
            });

            await Insert(new QuestionModel
            {
                Id = 6,
                Title = "How strong is your support system?",
                Choices = JsonConvert.SerializeObject(
                    new List<ChoiceModel>
                    {
                        new ChoiceModel(1, "Very strong - I can count on the people in my life"),
                        new ChoiceModel(2, "Medium - I worry people won't be there"),
                        new ChoiceModel(3, "Weak - I feel isolated"),
                    })
            });

            await Insert(new QuestionModel
            {
                Id = 7,
                Title = "Even when things are going well, do you feel...",
                Choices = JsonConvert.SerializeObject(
                    new List<ChoiceModel>
                    {
                        new ChoiceModel(1, "Unfulfilled"),
                        new ChoiceModel(2, "Frustrated"),
                        new ChoiceModel(3, "Disconnected"),
                        new ChoiceModel(4, "Fine"),
                    })
            });

            await Insert(new QuestionModel
            {
                Id = 8,
                Title = "How distractable are you?",
                Choices = JsonConvert.SerializeObject(
                    new List<ChoiceModel>
                    {
                        new ChoiceModel(1, "Easily distracted"),
                        new ChoiceModel(2, "Sometimes lose focus"),
                        new ChoiceModel(3, "Rarely lose focus"),
                        new ChoiceModel(4, "Laser focus"),
                    })
            });

            await Insert(new QuestionModel
            {
                Id = 9,
                Title = "What habits below most trouble you?",
                Choices = JsonConvert.SerializeObject(
                    new List<ChoiceModel>
                    {
                        new ChoiceModel(1, "Social Media"),
                        new ChoiceModel(2, "Smoking"),
                        new ChoiceModel(3, "Sugar"),
                        new ChoiceModel(4, "Other"),
                    })
            });

            await Insert(new QuestionModel
            {
                Id = 10,
                Title = "If you did not have to hide from others or yourself, what might emerge?",
                Choices = JsonConvert.SerializeObject(
                    new List<ChoiceModel>
                    {
                        new ChoiceModel(1, "Satisfaction and achievement"),
                        new ChoiceModel(2, "Unexplored paths"),
                        new ChoiceModel(3, "A sense of ease"),
                        new ChoiceModel(4, "My life's purpose"),
                    })
            });

            await Insert(new QuestionModel
            {
                Id = 11,
                Title = "Why are you embarking on this journey to build healthy habits?",
                Choices = JsonConvert.SerializeObject(
                    new List<ChoiceModel>
                    {
                        new ChoiceModel(1, "To feel better about myself"),
                        new ChoiceModel(2, "To improve my health"),
                        new ChoiceModel(3, "To set and achieve goals"),
                        new ChoiceModel(4, "To be more like someone who I admire"),
                    })
            });

            var newGet = await Get();

            Console.WriteLine(newGet);
        }
    }
}
