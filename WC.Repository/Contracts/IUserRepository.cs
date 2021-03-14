using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WC.Model;

namespace WC.Repository.Contracts
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers();
        User GetNoteById(int id);
        void InsertUser(User user);
        void DeleteUser(int userId);
        void UpdateUser(User user);
        void Save();
    }
}
