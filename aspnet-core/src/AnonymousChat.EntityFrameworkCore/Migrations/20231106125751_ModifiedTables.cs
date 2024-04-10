using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnonymousChat.Migrations
{
    /// <inheritdoc />
    public partial class ModifiedTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_RegisteredUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnonymousName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrentAvatarPath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_RegisteredUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_AvatarChangeHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegisteredUserId = table.Column<int>(type: "int", nullable: false),
                    AvatarPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateTimeOfStored = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_AvatarChangeHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_AvatarChangeHistory_tbl_RegisteredUsers_RegisteredUserId",
                        column: x => x.RegisteredUserId,
                        principalTable: "tbl_RegisteredUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_LoginHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegisteredUserId = table.Column<int>(type: "int", nullable: false),
                    LoginFromLat = table.Column<double>(type: "float", nullable: true),
                    LoginFromLong = table.Column<double>(type: "float", nullable: true),
                    LoginDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OTP = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_LoginHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_LoginHistory_tbl_RegisteredUsers_RegisteredUserId",
                        column: x => x.RegisteredUserId,
                        principalTable: "tbl_RegisteredUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_NameChangeHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegisteredUserId = table.Column<int>(type: "int", nullable: false),
                    AnonymousPreviousName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateTimeOfStored = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_NameChangeHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_NameChangeHistory_tbl_RegisteredUsers_RegisteredUserId",
                        column: x => x.RegisteredUserId,
                        principalTable: "tbl_RegisteredUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Post",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegisteredUserId = table.Column<int>(type: "int", nullable: false),
                    DateTimeOfPost = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Caption = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Keywords = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tags = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Post", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_Post_tbl_RegisteredUsers_RegisteredUserId",
                        column: x => x.RegisteredUserId,
                        principalTable: "tbl_RegisteredUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostId = table.Column<int>(type: "int", nullable: false),
                    RegisteredUsersId = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_Comments_tbl_Post_PostId",
                        column: x => x.PostId,
                        principalTable: "tbl_Post",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_Comments_tbl_RegisteredUsers_RegisteredUsersId",
                        column: x => x.RegisteredUsersId,
                        principalTable: "tbl_RegisteredUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_EditPostHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostId = table.Column<int>(type: "int", nullable: false),
                    Caption = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EditedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_EditPostHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_EditPostHistory_tbl_Post_PostId",
                        column: x => x.PostId,
                        principalTable: "tbl_Post",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_CommentsEditHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommentsId = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EditedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_CommentsEditHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_CommentsEditHistory_tbl_Comments_CommentsId",
                        column: x => x.CommentsId,
                        principalTable: "tbl_Comments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_AvatarChangeHistory_RegisteredUserId",
                table: "tbl_AvatarChangeHistory",
                column: "RegisteredUserId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Comments_PostId",
                table: "tbl_Comments",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Comments_RegisteredUsersId",
                table: "tbl_Comments",
                column: "RegisteredUsersId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_CommentsEditHistory_CommentsId",
                table: "tbl_CommentsEditHistory",
                column: "CommentsId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_EditPostHistory_PostId",
                table: "tbl_EditPostHistory",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_LoginHistory_RegisteredUserId",
                table: "tbl_LoginHistory",
                column: "RegisteredUserId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_NameChangeHistory_RegisteredUserId",
                table: "tbl_NameChangeHistory",
                column: "RegisteredUserId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Post_RegisteredUserId",
                table: "tbl_Post",
                column: "RegisteredUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_AvatarChangeHistory");

            migrationBuilder.DropTable(
                name: "tbl_CommentsEditHistory");

            migrationBuilder.DropTable(
                name: "tbl_EditPostHistory");

            migrationBuilder.DropTable(
                name: "tbl_LoginHistory");

            migrationBuilder.DropTable(
                name: "tbl_NameChangeHistory");

            migrationBuilder.DropTable(
                name: "tbl_Comments");

            migrationBuilder.DropTable(
                name: "tbl_Post");

            migrationBuilder.DropTable(
                name: "tbl_RegisteredUsers");
        }
    }
}
