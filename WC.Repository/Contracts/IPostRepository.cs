using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WC.Model;

namespace WC.Repository.Contracts
{
    public interface IPostRepository
    {
        IEnumerable<Post> GetPosts();
        Post GetPostById(int id);
        void CreatePost(Post post);
        void DeletePost(int postId);
        void UpdatePost(Post post);
        void Save();
    }
}
