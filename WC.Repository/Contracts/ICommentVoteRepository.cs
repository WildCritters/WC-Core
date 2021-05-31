using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WC.Model;

namespace WC.Repository.Contracts
{
    public interface ICommentVoteRepository
    {
        IEnumerable<CommentVote> GetCommentVotes();
        CommentVote GetCommentVoteById(int id);
        void CreateCommentVote(CommentVote commentVote);
        void DeleteCommentVote(int commentVoteId);
        void UpdateCommentVote(CommentVote comment);
        void Save();
    }
}
