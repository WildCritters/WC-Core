using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WC.Model;

namespace WC.Repository.Contracts
{
    public interface IPostTagRepository
    {
        IEnumerable<PostTag> GetPostTags();
        PostTag GetPostTagById(int id);
        void CreatePostTag(PostTag postTag);
        void DeletePostTag(int postTagId);
        void UpdatePostTag(PostTag postTag);
        void Save();
    }
}
