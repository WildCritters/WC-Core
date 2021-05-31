using System.Collections.Generic;
using WC.Model;

namespace WC.Repository.Contracts
{
    public interface ITagRepository
    {
        IEnumerable<Tag> GetTags();
        Tag GetTagById(int id);
        void CreateTag(Tag tag);
        void DeleteTag(int tagId);
        void UpdateTag(Tag tag);
        void Save();
    }
}