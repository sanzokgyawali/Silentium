using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnonymousChat.Migrations
{
    /// <inheritdoc />
    public partial class @try : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_GroupDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_GroupDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_PrivateChat",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReceiverId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_PrivateChat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_PrivateChat_tbl_RegisteredUsers_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "tbl_RegisteredUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GroupDetailsRegisteredUsers",
                columns: table => new
                {
                    GroupDetailsId = table.Column<int>(type: "int", nullable: false),
                    MembersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupDetailsRegisteredUsers", x => new { x.GroupDetailsId, x.MembersId });
                    table.ForeignKey(
                        name: "FK_GroupDetailsRegisteredUsers_tbl_GroupDetails_GroupDetailsId",
                        column: x => x.GroupDetailsId,
                        principalTable: "tbl_GroupDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupDetailsRegisteredUsers_tbl_RegisteredUsers_MembersId",
                        column: x => x.MembersId,
                        principalTable: "tbl_RegisteredUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_GroupChat",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupDetailId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_GroupChat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_GroupChat_tbl_GroupDetails_GroupDetailId",
                        column: x => x.GroupDetailId,
                        principalTable: "tbl_GroupDetails",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "tbl_Message",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MessageContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MessageTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SenderId = table.Column<int>(type: "int", nullable: true),
                    IsPrivate = table.Column<bool>(type: "bit", nullable: false),
                    GroupChatId = table.Column<int>(type: "int", nullable: true),
                    PrivateChatId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Message", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_Message_tbl_GroupChat_GroupChatId",
                        column: x => x.GroupChatId,
                        principalTable: "tbl_GroupChat",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tbl_Message_tbl_PrivateChat_PrivateChatId",
                        column: x => x.PrivateChatId,
                        principalTable: "tbl_PrivateChat",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tbl_Message_tbl_RegisteredUsers_SenderId",
                        column: x => x.SenderId,
                        principalTable: "tbl_RegisteredUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_GroupDetailsRegisteredUsers_MembersId",
                table: "GroupDetailsRegisteredUsers",
                column: "MembersId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_GroupChat_GroupDetailId",
                table: "tbl_GroupChat",
                column: "GroupDetailId",
                unique: true,
                filter: "[GroupDetailId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Message_GroupChatId",
                table: "tbl_Message",
                column: "GroupChatId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Message_PrivateChatId",
                table: "tbl_Message",
                column: "PrivateChatId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Message_SenderId",
                table: "tbl_Message",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_PrivateChat_ReceiverId",
                table: "tbl_PrivateChat",
                column: "ReceiverId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroupDetailsRegisteredUsers");

            migrationBuilder.DropTable(
                name: "tbl_Message");

            migrationBuilder.DropTable(
                name: "tbl_GroupChat");

            migrationBuilder.DropTable(
                name: "tbl_PrivateChat");

            migrationBuilder.DropTable(
                name: "tbl_GroupDetails");
        }
    }
}
