using FlightAlertData.Alert;
using FlightAlertData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAlertData.User
{
    public class UserData: IUserData
    {
        private readonly FlightContext _flightContext;
        public UserData(FlightContext flightContext)
        {
            _flightContext = flightContext;
        }

        public IQueryable<UserDTO> GetUsers()
        {
            IQueryable<UserDTO> users = _flightContext.Users
                .Select(user => new UserDTO
                {
                    UserId = user.UserId,
                    Name = user.Name,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber
                });

            if (users == null || !users.Any())
            {
                return null;
            }

            return users;
        }

        public async Task<UserDTO> GetUser(int id)
        {
            Users usersEntity = await _flightContext.Users.FindAsync(id);

            if (usersEntity == null)
            {
                return null;
            }

            UserDTO user = new UserDTO
            {
                UserId = usersEntity.UserId,
                Name = usersEntity.Name,
                Email = usersEntity.Email,
                PhoneNumber = usersEntity.PhoneNumber
            };

            return user;
        }

        public async Task<bool> CreateUser(UserDTO user)
        {
            Users userContext = new Users
            {
                UserId = user.UserId,
                Name = user.Name,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber
            };

            _flightContext.Users.Add(userContext);

            int result = await _flightContext.SaveChangesAsync();

            return result > 0; // Returns true if one or more state entries were written to the database
        }

        public async Task<bool> UpdateUser(UserDTO user)
        {
            Users userContext = new Users
            {
                UserId = user.UserId,
                Name = user.Name,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber
            };

            _flightContext.Entry(userContext).State = EntityState.Modified;
            int result = await _flightContext.SaveChangesAsync();

            return result > 0; // Returns true if one or more state entries were written to the database
        }

        public async Task<bool> DeleteUser(int id)
        {
            Users user = await _flightContext.Users.FindAsync(id);
            if (user == null)
            {
                return false;
            }

            _flightContext.Users.Remove(user);
            int result = await _flightContext.SaveChangesAsync();

            return result > 0; // Returns true if one or more state entries were written to the database
        }
    }
}
