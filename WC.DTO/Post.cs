using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WC.DTO
{
    public class Post
    {
        public string Extension { get; set; }
        public int Size { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int UpScore { get; set; }
        public int DownScore { get; set; }
        public int Score { get; set; }
        public string Source { get; set; }
        public string Hash { get; set; }
        public string Rating { get; set; }
        public bool NoteLocked { get; set; }
        public bool RatingLocked { get; set; }
        public bool StatusLocked { get; set; }
        public string Status { get; set; } //Pending, Flagged, Deleted
        public DateTimeOffset LastCommented { get; set; }
        public DateTimeOffset LastNote { get; set; }
        public int FavouriteCount { get; set; }
        public int UploaderId { get; set; }
        public virtual User Uploader { get; set; }
        public int ApproverId { get; set; }
        public virtual User Approver { get; set; }
        public int ParentId { get; set; }
        public virtual Post Parent { get; set; }
    }
}
