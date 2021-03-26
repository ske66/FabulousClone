using FabulousClone.IRepositories;
using FabulousClone.Models;
using SQLite;
using System;
using System.Text;

namespace FabulousClone.Repositories
{
    public class UserRepository : Repository<UserModel>, IUserRepository
    {
        public UserRepository()
        {
            
        }
    }
}
