using FlightAlertData.Alert;
using FlightAlertData.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAlertLogic.User
{
    public class UserLogic : IUserLogic
    {
        private readonly IUserData _userData;

        public UserLogic(IUserData userData)
        {
            _userData = userData;
        }

        public IQueryable<UserDTO> GetUsers()
        {
            return _userData.GetUsers();
        }

        public async Task<UserDTO> GetUser(int id)
        {
            return await _userData.GetUser(id);
        }

        public async Task<bool> CreateUser(UserDTO user)
        {
            return await _userData.CreateUser(user);
        }

        public async Task<bool> UpdateUser(UserDTO user)
        {
            return await _userData.UpdateUser(user);
        }

        public async Task<bool> DeleteUser(int id)
        {
            return await _userData.DeleteUser(id);
        }
    }
}
