using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WC.Context.Migrations
{
    public partial class Inital_Domain_model : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Function",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DateOfCreation = table.Column<DateTimeOffset>(nullable: false),
                    LastUpdate = table.Column<DateTimeOffset>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Function", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pool",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DateOfCreation = table.Column<DateTimeOffset>(nullable: false),
                    LastUpdate = table.Column<DateTimeOffset>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Category = table.Column<string>(nullable: true),
                    IsPublic = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pool", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DateOfCreation = table.Column<DateTimeOffset>(nullable: false),
                    LastUpdate = table.Column<DateTimeOffset>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DateOfCreation = table.Column<DateTimeOffset>(nullable: false),
                    LastUpdate = table.Column<DateTimeOffset>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    PostCount = table.Column<int>(nullable: false),
                    Category = table.Column<int>(nullable: false),
                    Ambigous = table.Column<bool>(nullable: false),
                    RelatedTags = table.Column<string>(nullable: true),
                    RelatedTagsUpdated = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleFunction",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DateOfCreation = table.Column<DateTimeOffset>(nullable: false),
                    LastUpdate = table.Column<DateTimeOffset>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    RoleId = table.Column<int>(nullable: false),
                    FunctionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleFunction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleFunction_Function_FunctionId",
                        column: x => x.FunctionId,
                        principalTable: "Function",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleFunction_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DateOfCreation = table.Column<DateTimeOffset>(nullable: false),
                    LastUpdate = table.Column<DateTimeOffset>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true),
                    Mail = table.Column<string>(nullable: true),
                    Ip = table.Column<string>(nullable: true),
                    Banned = table.Column<bool>(nullable: false),
                    BanReason = table.Column<string>(nullable: true),
                    Level = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Alias",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DateOfCreation = table.Column<DateTimeOffset>(nullable: false),
                    LastUpdate = table.Column<DateTimeOffset>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Reason = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alias_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Avatar",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DateOfCreation = table.Column<DateTimeOffset>(nullable: false),
                    LastUpdate = table.Column<DateTimeOffset>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Extension = table.Column<string>(nullable: true),
                    Height = table.Column<int>(nullable: false),
                    Width = table.Column<int>(nullable: false),
                    Hash = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avatar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Avatar_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ForumTopic",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DateOfCreation = table.Column<DateTimeOffset>(nullable: false),
                    LastUpdate = table.Column<DateTimeOffset>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    ResponseCount = table.Column<int>(nullable: false),
                    Sticky = table.Column<bool>(nullable: false),
                    Locked = table.Column<bool>(nullable: false),
                    Priority = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForumTopic", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ForumTopic_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Mail",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DateOfCreation = table.Column<DateTimeOffset>(nullable: false),
                    LastUpdate = table.Column<DateTimeOffset>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    SenderId = table.Column<int>(nullable: false),
                    Receiverid = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Body = table.Column<string>(nullable: true),
                    HasSeen = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mail_User_Receiverid",
                        column: x => x.Receiverid,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Mail_User_SenderId",
                        column: x => x.SenderId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DateOfCreation = table.Column<DateTimeOffset>(nullable: false),
                    LastUpdate = table.Column<DateTimeOffset>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Extension = table.Column<string>(nullable: true),
                    Size = table.Column<int>(nullable: false),
                    Width = table.Column<int>(nullable: false),
                    Height = table.Column<int>(nullable: false),
                    UpScore = table.Column<int>(nullable: false),
                    DownScore = table.Column<int>(nullable: false),
                    Score = table.Column<int>(nullable: false),
                    Source = table.Column<string>(nullable: true),
                    Hash = table.Column<string>(nullable: true),
                    Rating = table.Column<string>(nullable: true),
                    NoteLocked = table.Column<bool>(nullable: false),
                    RatingLocked = table.Column<bool>(nullable: false),
                    StatusLocked = table.Column<bool>(nullable: false),
                    Status = table.Column<string>(nullable: true),
                    LastCommented = table.Column<DateTimeOffset>(nullable: false),
                    LastNote = table.Column<DateTimeOffset>(nullable: false),
                    FavouriteCount = table.Column<int>(nullable: false),
                    UploaderId = table.Column<int>(nullable: false),
                    ApproverId = table.Column<int>(nullable: false),
                    ParentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Post_User_ApproverId",
                        column: x => x.ApproverId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Post_Post_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Post",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Post_User_UploaderId",
                        column: x => x.UploaderId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserData",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DateOfCreation = table.Column<DateTimeOffset>(nullable: false),
                    LastUpdate = table.Column<DateTimeOffset>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    LastLoggedAt = table.Column<DateTimeOffset>(nullable: false),
                    LastForumReadAt = table.Column<DateTimeOffset>(nullable: false),
                    RecentTags = table.Column<string>(nullable: true),
                    PostUploadCount = table.Column<int>(nullable: false),
                    PostUpdateCount = table.Column<int>(nullable: false),
                    NoteUpdateCount = table.Column<int>(nullable: false),
                    FavouriteCount = table.Column<int>(nullable: false),
                    NotificationActive = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserData_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserSettings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DateOfCreation = table.Column<DateTimeOffset>(nullable: false),
                    LastUpdate = table.Column<DateTimeOffset>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    ReceiveMailNotifications = table.Column<bool>(nullable: false),
                    CommentThreshold = table.Column<int>(nullable: false),
                    AlwaysResizeImages = table.Column<bool>(nullable: false),
                    DefaultImageSize = table.Column<string>(nullable: true),
                    Tags = table.Column<string>(nullable: true),
                    BlacklistTags = table.Column<string>(nullable: true),
                    TimeZone = table.Column<string>(nullable: true),
                    SafeMode = table.Column<bool>(nullable: false),
                    Theme = table.Column<string>(nullable: true),
                    BlacklistUsers = table.Column<string>(nullable: true),
                    SignatureTitle = table.Column<string>(nullable: true),
                    SignatureBody = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSettings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserSettings_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WikiPage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DateOfCreation = table.Column<DateTimeOffset>(nullable: false),
                    LastUpdate = table.Column<DateTimeOffset>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Body = table.Column<string>(nullable: true),
                    Version = table.Column<string>(nullable: true),
                    Ip = table.Column<string>(nullable: true),
                    Locked = table.Column<bool>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WikiPage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WikiPage_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ForumPost",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DateOfCreation = table.Column<DateTimeOffset>(nullable: false),
                    LastUpdate = table.Column<DateTimeOffset>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Body = table.Column<string>(nullable: true),
                    TopicId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForumPost", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ForumPost_ForumTopic_TopicId",
                        column: x => x.TopicId,
                        principalTable: "ForumTopic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DateOfCreation = table.Column<DateTimeOffset>(nullable: false),
                    LastUpdate = table.Column<DateTimeOffset>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    PostedAt = table.Column<DateTimeOffset>(nullable: false),
                    Body = table.Column<string>(nullable: true),
                    Score = table.Column<int>(nullable: false),
                    Ip = table.Column<string>(nullable: true),
                    PostId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Post_PostId",
                        column: x => x.PostId,
                        principalTable: "Post",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Favorites",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DateOfCreation = table.Column<DateTimeOffset>(nullable: false),
                    LastUpdate = table.Column<DateTimeOffset>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    PostId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favorites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Favorites_Post_PostId",
                        column: x => x.PostId,
                        principalTable: "Post",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Favorites_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FlaggedPost",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DateOfCreation = table.Column<DateTimeOffset>(nullable: false),
                    LastUpdate = table.Column<DateTimeOffset>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Reason = table.Column<string>(nullable: true),
                    Resolved = table.Column<bool>(nullable: false),
                    ResolvedDate = table.Column<DateTimeOffset>(nullable: false),
                    StaffComment = table.Column<string>(nullable: true),
                    StaffAction = table.Column<string>(nullable: true),
                    DMailSent = table.Column<bool>(nullable: false),
                    StaffuserId = table.Column<int>(nullable: false),
                    PostId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlaggedPost", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FlaggedPost_Post_PostId",
                        column: x => x.PostId,
                        principalTable: "Post",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FlaggedPost_User_StaffuserId",
                        column: x => x.StaffuserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FlaggedPost_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PoolPost",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DateOfCreation = table.Column<DateTimeOffset>(nullable: false),
                    LastUpdate = table.Column<DateTimeOffset>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Sequence = table.Column<int>(nullable: false),
                    PoolId = table.Column<int>(nullable: false),
                    PostId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PoolPost", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PoolPost_Pool_PoolId",
                        column: x => x.PoolId,
                        principalTable: "Pool",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PoolPost_Post_PostId",
                        column: x => x.PostId,
                        principalTable: "Post",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PostTag",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DateOfCreation = table.Column<DateTimeOffset>(nullable: false),
                    LastUpdate = table.Column<DateTimeOffset>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    PostId = table.Column<int>(nullable: false),
                    TagId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostTag", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostTag_Post_PostId",
                        column: x => x.PostId,
                        principalTable: "Post",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostTag_Tag_TagId",
                        column: x => x.TagId,
                        principalTable: "Tag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WikiPageVersion",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DateOfCreation = table.Column<DateTimeOffset>(nullable: false),
                    LastUpdate = table.Column<DateTimeOffset>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Body = table.Column<string>(nullable: true),
                    Version = table.Column<string>(nullable: true),
                    Ip = table.Column<string>(nullable: true),
                    Locked = table.Column<bool>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    WikiId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WikiPageVersion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WikiPageVersion_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WikiPageVersion_WikiPage_WikiId",
                        column: x => x.WikiId,
                        principalTable: "WikiPage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CommentVote",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DateOfCreation = table.Column<DateTimeOffset>(nullable: false),
                    LastUpdate = table.Column<DateTimeOffset>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    PostId = table.Column<int>(nullable: false),
                    CommentId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentVote", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommentVote_Comments_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommentVote_Post_PostId",
                        column: x => x.PostId,
                        principalTable: "Post",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommentVote_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alias_UserId",
                table: "Alias",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Avatar_UserId",
                table: "Avatar",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostId",
                table: "Comments",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentVote_CommentId",
                table: "CommentVote",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentVote_PostId",
                table: "CommentVote",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentVote_UserId",
                table: "CommentVote",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_PostId",
                table: "Favorites",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_UserId",
                table: "Favorites",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FlaggedPost_PostId",
                table: "FlaggedPost",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_FlaggedPost_StaffuserId",
                table: "FlaggedPost",
                column: "StaffuserId");

            migrationBuilder.CreateIndex(
                name: "IX_FlaggedPost_UserId",
                table: "FlaggedPost",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ForumPost_TopicId",
                table: "ForumPost",
                column: "TopicId");

            migrationBuilder.CreateIndex(
                name: "IX_ForumTopic_UserId",
                table: "ForumTopic",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Mail_Receiverid",
                table: "Mail",
                column: "Receiverid");

            migrationBuilder.CreateIndex(
                name: "IX_Mail_SenderId",
                table: "Mail",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_PoolPost_PoolId",
                table: "PoolPost",
                column: "PoolId");

            migrationBuilder.CreateIndex(
                name: "IX_PoolPost_PostId",
                table: "PoolPost",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_ApproverId",
                table: "Post",
                column: "ApproverId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_ParentId",
                table: "Post",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_UploaderId",
                table: "Post",
                column: "UploaderId");

            migrationBuilder.CreateIndex(
                name: "IX_PostTag_PostId",
                table: "PostTag",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_PostTag_TagId",
                table: "PostTag",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleFunction_FunctionId",
                table: "RoleFunction",
                column: "FunctionId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleFunction_RoleId",
                table: "RoleFunction",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_User_RoleId",
                table: "User",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserData_UserId",
                table: "UserData",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSettings_UserId",
                table: "UserSettings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_WikiPage_UserId",
                table: "WikiPage",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_WikiPageVersion_UserId",
                table: "WikiPageVersion",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_WikiPageVersion_WikiId",
                table: "WikiPageVersion",
                column: "WikiId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alias");

            migrationBuilder.DropTable(
                name: "Avatar");

            migrationBuilder.DropTable(
                name: "CommentVote");

            migrationBuilder.DropTable(
                name: "Favorites");

            migrationBuilder.DropTable(
                name: "FlaggedPost");

            migrationBuilder.DropTable(
                name: "ForumPost");

            migrationBuilder.DropTable(
                name: "Mail");

            migrationBuilder.DropTable(
                name: "PoolPost");

            migrationBuilder.DropTable(
                name: "PostTag");

            migrationBuilder.DropTable(
                name: "RoleFunction");

            migrationBuilder.DropTable(
                name: "UserData");

            migrationBuilder.DropTable(
                name: "UserSettings");

            migrationBuilder.DropTable(
                name: "WikiPageVersion");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "ForumTopic");

            migrationBuilder.DropTable(
                name: "Pool");

            migrationBuilder.DropTable(
                name: "Tag");

            migrationBuilder.DropTable(
                name: "Function");

            migrationBuilder.DropTable(
                name: "WikiPage");

            migrationBuilder.DropTable(
                name: "Post");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}
