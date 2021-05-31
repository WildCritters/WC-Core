using System.Collections.Generic;
using WC.Model;

namespace WC.Repository.Contracts
{
    public interface IFlaggedPostRepository
    {
        IEnumerable<FlaggedPost> GetFlaggedPosts();
        FlaggedPost GetFlaggedPostById(int id);
        void CreateFlaggedPost(FlaggedPost flaggedPost);
        void DeleteFlaggedPost(int flaggedPostId);
        void UpdateFlaggedPost(FlaggedPost flaggedPost);
        void Save();
    }
}