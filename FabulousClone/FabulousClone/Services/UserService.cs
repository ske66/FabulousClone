using FabulousClone.IRepositories;
using FabulousClone.IServices;
using FabulousClone.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FabulousClone.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserModel User { get; set; }

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> GetUser()
        {
            User = await _userRepository.FindById(1);

            return User != null;
        }

        public async Task SaveUserDetails() => await _userRepository.Insert(User);
        

    }
}
