using System.Collections.Generic;
using WC.Model;

namespace WC.Repository.Implementations
{
    interface IForumTopicRepository
    {
        IEnumerable<ForumTopic> GetForumTopics();
        ForumTopic GetForumTopicById(int id);
        void CreateForumTopic(ForumTopic forumTopic);
        void DeleteForumTopic(int forumTopicId);
        void UpdateForumTopic(ForumTopic forumTopic);
        void Save();
    }
}