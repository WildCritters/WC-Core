using System.Collections.Generic;
using WC.Model;

namespace WC.Repository.Contracts
{
    public interface ICommentRepository
    {
        IEnumerable<Comment> GetComments();
        Comment GetCommentById(int id);
        void CreateComment(Comment comment);
        void DeleteComment(int commentId);
        void UpdateComment(Comment comment);
        void Save();
    }
}
