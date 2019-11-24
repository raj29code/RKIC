using Service.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Users.Interface
{
    public interface IUserService
    {
        Task<bool> createUser(User saveCustomColumnRequestData);

        Task<User> GetUserByIdAndPassword(string Username, string password);
        Task<User> GetUserById(string Username);

        Task<bool> UpdateUser(User User);


    }
}