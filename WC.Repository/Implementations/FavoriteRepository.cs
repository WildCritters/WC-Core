using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WC.Context;
using WC.Model;

namespace WC.Repository.Implementations
{
    public class FavoriteRepository
    {
        private readonly WildCrittersDBContext context;

        public FavoriteRepository(WildCrittersDBContext context)
        {
            this.context = context;
        }

        public IEnumerable<Favorite> GetFavorites()
        {
            return context.Favorites.ToList();
        }

        public Favorite GetFavoriteById(int id)
        {
            return context.Favorites.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public void CreateFavorite(Favorite favorite)
        {
            favorite.Active = true;
            favorite.DateOfCreation = DateTimeOffset.Now;
            favorite.LastUpdate = DateTimeOffset.Now;
            context.Favorites.Add(favorite);
        }

        public void DeleteFavorite(int favoriteId)
        {
            Favorite favorite = context.Favorites.Find(favoriteId);
            context.Favorites.Remove(favorite);
        }

        public void UpdateFavorite(Favorite favorite)
        {
            favorite.LastUpdate = DateTimeOffset.Now;
            context.Entry(favorite).State = EntityState.Modified;
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