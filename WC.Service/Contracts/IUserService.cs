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
        User GetNoteById(int id);
        void InsertUser(string userName, string password, string mail, string timeZone, string ip);
        void DeleteUser(int userId);
        void UpdateUser(string userName, string password, string mail, string timeZone, string ip);
    }
}
