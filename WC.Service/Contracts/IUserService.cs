using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WC.DTO;

namespace WC.Service.Contracts
{
    public interface IUserService
    {
        IEnumerable<User> GetUsers();
        User GetUserById(int id);
        void CreateUser(string username, string password, string mail, string ip, bool banned, string banReason, int level, int roleId);
        void DeleteLogicUser(int userId);
        void DeleteUser(int userId);
        void UpdateUser(string username, string password, string mail, string ip, bool banned, string banReason, int level, int roleId, int userId);
        void resetPassword(int userId, string password);
    }
}
