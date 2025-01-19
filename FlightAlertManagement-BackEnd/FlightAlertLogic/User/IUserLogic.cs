using FlightAlertData.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAlertLogic.User
{
    public interface IUserLogic
    {
        public IQueryable<UserDTO> GetUsers();
        public Task<UserDTO> GetUser(int id);
        public Task<bool> CreateUser(UserDTO user);
        public Task<bool> UpdateUser(UserDTO user);
        public Task<bool> DeleteUser(int id);
    }
}
