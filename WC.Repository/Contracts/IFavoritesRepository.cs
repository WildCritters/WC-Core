using System.Collections.Generic;
using WC.Model;

namespace WC.Repository.Contracts
{
    public interface IFavoriteRepository
    {
        IEnumerable<Favorite> GetFavorites();
        Favorite GetFavoriteById(int id);
        void CreateFavorite(Favorite favorite);
        void DeleteFavorite(int favoriteId);
        void UpdateFavorite(Favorite favorite);
        void Save();
    }
}