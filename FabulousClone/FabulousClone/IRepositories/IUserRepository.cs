using FabulousClone.Models;
using FabulousClone.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FabulousClone.IRepositories
{
    public interface IUserRepository : IRepository<UserModel>
    {
    }
}
