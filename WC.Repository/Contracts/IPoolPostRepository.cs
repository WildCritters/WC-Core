using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WC.Model;

namespace WC.Repository.Contracts
{
    public interface IPoolPostRepository
    {
        IEnumerable<PoolPost> GetPoolPosts();
        PoolPost GetPoolPostById(int id);
        void CreatePoolPost(PoolPost poolPost);
        void DeletePoolPost(int poolPostId);
        void UpdatePoolPost(PoolPost poolPost);
        void Save();
    }
}
