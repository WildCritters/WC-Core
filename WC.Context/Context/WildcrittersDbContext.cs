using Microsoft.EntityFrameworkCore;
using WC.Model;

namespace WC.Context
{
    public class WildCrittersDBContext : DbContext
    {
        public WildCrittersDBContext() {}

        public WildCrittersDBContext(DbContextOptions<WildCrittersDBContext> options)
            : base(options) {}

        public DbSet<User> Emotes { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Function> Functions { get; set; }
        public DbSet<RoleFunction> RoleFunctions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Alias> Aliases { get; set; }
        public DbSet<Avatar> Avatars { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<CommentVote> CommentVotes { get; set; }
        public DbSet<Favorites> Favorites { get; set; }
        public DbSet<FlaggedPost> FlaggedPosts { get; set; }
        public DbSet<ForumPost> ForumPosts { get; set; }
        public DbSet<ForumTopic> ForumTopics { get; set; }
        public DbSet<Mail> Mails { get; set; }
        public DbSet<Pool> Pools { get; set; }
        public DbSet<PoolPost> PoolPosts { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostTag> PostTags { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<UserData> UserDatas { get; set; }
        public DbSet<UserSettings> UserSettings { get; set; }
        public DbSet<WikiPage> WikiPages { get; set; }
        public DbSet<WikiPageVersion> WikiPageVersions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>().HasIndex(p => new { p.Hash }).IsUnique();
            modelBuilder.Entity<Post>().HasIndex(p => new { p.DateOfCreation });
            modelBuilder.Entity<Post>().HasIndex(p => new { p.LastCommented });
            modelBuilder.Entity<Post>().HasIndex(p => new { p.LastNote });
            modelBuilder.Entity<Post>().HasIndex(p => new { p.Size });
            modelBuilder.Entity<Post>().HasIndex(p => new { p.Width });
            modelBuilder.Entity<Post>().HasIndex(p => new { p.Height });
            modelBuilder.Entity<Post>().HasIndex(p => new { p.UploaderId });
            modelBuilder.Entity<Post>().HasIndex(p => new { p.ApproverId });
            modelBuilder.Entity<Post>().HasIndex(p => new { p.Status });

            modelBuilder.Entity<Tag>().HasIndex(p => new { p.Name }).IsUnique();

            //modelBuilder.Entity<PoolPost>().HasIndex(p => new { p.PoolId }).IsUnique();
            //modelBuilder.Entity<PoolPost>().HasIndex(p => new { p.PostId }).IsUnique();

            //modelBuilder.Entity<Comment>().HasIndex(p => new { p.PostId }).IsUnique();
        }
    }
}