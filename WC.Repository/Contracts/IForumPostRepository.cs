using System.Collections.Generic;
using WC.Model;

namespace WC.Repository.Implementations
{
    public interface IForumPostRepository
    {
        IEnumerable<ForumPost> GetForumPosts();
        ForumPost GetForumPostById(int id);
        void CreateForumPost(ForumPost forumPost);
        void DeleteForumPost(int forumPostId);
        void UpdateForumPost(ForumPost forumPost);
        void Save();
    }
}