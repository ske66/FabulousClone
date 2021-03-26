using FabulousClone.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FabulousClone.IServices
{
    public interface IUserService
    {
        UserModel User { get; set; }
        Task<bool> GetUser();
        Task SaveUserDetails();
    }
}
