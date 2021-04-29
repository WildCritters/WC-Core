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
    public class AvatarRepository : IAvatarRepository, IDisposable
    {
        private readonly WildCrittersDBContext context;

        public AvatarRepository(WildCrittersDBContext context)
        {
            this.context = context;
        }

        public IEnumerable<Avatar> GetAvatars()
        {
            return context.Avatars.ToList();
        }

        public Avatar GetAvatarById(int id)
        {
            return context.Avatars.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public void CreateAvatar(Avatar avatar)
        {
            avatar.Active = true;
            avatar.DateOfCreation = DateTimeOffset.Now;
            avatar.LastUpdate = DateTimeOffset.Now;
            context.Avatars.Add(avatar);
        }

        public void DeleteAvatar(int avatarId)
        {
            Avatar avatar = context.Avatars.Find(avatarId);
            context.Avatars.Remove(avatar);
        }

        public void UpdateAvatar(Avatar avatar)
        {
            avatar.LastUpdate = DateTimeOffset.Now;
            context.Entry(avatar).State = EntityState.Modified;
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
