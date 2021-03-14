using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WC.Context;
using WC.Model;
using WC.Repository.Contracts;

namespace WC.Repository.Implementations
{
    public class UserRepository : IUserRepository, IDisposable
    {
        private WildCrittersDBContext context;

        public UserRepository(WildCrittersDBContext context)
        {
            this.context = context;
        }

        public IEnumerable<User> GetUsers()
        {
            return context.Users.ToList();
        }

        public User GetNoteById(int id)
        {
            return context.Users.Find(id);
        }

        public void InsertUser(User user)
        {
            user.Active = true;
            user.DateOfCreation = DateTimeOffset.Now;
            user.LastUpdate = DateTimeOffset.Now;
            context.Users.Add(user);
        }

        public void DeleteUser(int userId)
        {
            User user = context.Users.Find(userId);
            context.Users.Remove(user);
        }

        public void UpdateUser(User user)
        {
            user.LastUpdate = DateTimeOffset.Now;
            context.Entry(user).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
