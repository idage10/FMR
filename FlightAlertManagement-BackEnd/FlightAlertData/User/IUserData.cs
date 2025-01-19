using System.Linq;
using System.Threading.Tasks;

namespace FlightAlertData.User
{
    public interface IUserData
    {
        public IQueryable<UserDTO> GetUsers();
        public Task<UserDTO> GetUser(int id);
        public Task<bool> CreateUser(UserDTO user);
        public Task<bool> UpdateUser(UserDTO user);
        public Task<bool> DeleteUser(int id);
    }
}
