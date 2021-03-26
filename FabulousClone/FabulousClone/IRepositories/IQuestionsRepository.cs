using FabulousClone.Models;
using System.Threading.Tasks;

namespace FabulousClone.IRepositories
{
    public interface IQuestionsRepository : IRepository<QuestionModel>
    {
        Task PopulateDatabase();

    }
}
