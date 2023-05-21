using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ModelsApi.Data.Migrations
{
    public partial class chatrooms : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Chats_ChatId",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Annonces_Chats_ChatId",
                table: "Annonces");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Chats_ChatId",
                table: "Messages");

            migrationBuilder.DropTable(
                name: "Chats");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_ChatId",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "ChatId",
                table: "Accounts");

            migrationBuilder.RenameColumn(
                name: "Messages",
                table: "Messages",
                newName: "Content");

            migrationBuilder.RenameColumn(
                name: "ChatId",
                table: "Messages",
                newName: "ChatRoomId");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_ChatId",
                table: "Messages",
                newName: "IX_Messages_ChatRoomId");

            migrationBuilder.RenameColumn(
                name: "ChatId",
                table: "Annonces",
                newName: "ChatRoomId");

            migrationBuilder.RenameIndex(
                name: "IX_Annonces_ChatId",
                table: "Annonces",
                newName: "IX_Annonces_ChatRoomId");

            migrationBuilder.AddColumn<long>(
                name: "EfManagerId",
                table: "Messages",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "TimeStamp",
                table: "Messages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "ChatRooms",
                columns: table => new
                {
                    ChatRoomId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatRooms", x => x.ChatRoomId);
                });

            migrationBuilder.CreateTable(
                name: "ChatRoomEfManager",
                columns: table => new
                {
                    ChatRoomsChatRoomId = table.Column<int>(type: "int", nullable: false),
                    EfManagersEfManagerId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatRoomEfManager", x => new { x.ChatRoomsChatRoomId, x.EfManagersEfManagerId });
                    table.ForeignKey(
                        name: "FK_ChatRoomEfManager_ChatRooms_ChatRoomsChatRoomId",
                        column: x => x.ChatRoomsChatRoomId,
                        principalTable: "ChatRooms",
                        principalColumn: "ChatRoomId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChatRoomEfManager_Managers_EfManagersEfManagerId",
                        column: x => x.EfManagersEfManagerId,
                        principalTable: "Managers",
                        principalColumn: "EfManagerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Messages_EfManagerId",
                table: "Messages",
                column: "EfManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatRoomEfManager_EfManagersEfManagerId",
                table: "ChatRoomEfManager",
                column: "EfManagersEfManagerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Annonces_ChatRooms_ChatRoomId",
                table: "Annonces",
                column: "ChatRoomId",
                principalTable: "ChatRooms",
                principalColumn: "ChatRoomId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_ChatRooms_ChatRoomId",
                table: "Messages",
                column: "ChatRoomId",
                principalTable: "ChatRooms",
                principalColumn: "ChatRoomId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Managers_EfManagerId",
                table: "Messages",
                column: "EfManagerId",
                principalTable: "Managers",
                principalColumn: "EfManagerId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Annonces_ChatRooms_ChatRoomId",
                table: "Annonces");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_ChatRooms_ChatRoomId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Managers_EfManagerId",
                table: "Messages");

            migrationBuilder.DropTable(
                name: "ChatRoomEfManager");

            migrationBuilder.DropTable(
                name: "ChatRooms");

            migrationBuilder.DropIndex(
                name: "IX_Messages_EfManagerId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "EfManagerId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "TimeStamp",
                table: "Messages");

            migrationBuilder.RenameColumn(
                name: "Content",
                table: "Messages",
                newName: "Messages");

            migrationBuilder.RenameColumn(
                name: "ChatRoomId",
                table: "Messages",
                newName: "ChatId");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_ChatRoomId",
                table: "Messages",
                newName: "IX_Messages_ChatId");

            migrationBuilder.RenameColumn(
                name: "ChatRoomId",
                table: "Annonces",
                newName: "ChatId");

            migrationBuilder.RenameIndex(
                name: "IX_Annonces_ChatRoomId",
                table: "Annonces",
                newName: "IX_Annonces_ChatId");

            migrationBuilder.AddColumn<int>(
                name: "ChatId",
                table: "Accounts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Chats",
                columns: table => new
                {
                    ChatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EfManagerId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chats", x => x.ChatId);
                    table.ForeignKey(
                        name: "FK_Chats_Managers_EfManagerId",
                        column: x => x.EfManagerId,
                        principalTable: "Managers",
                        principalColumn: "EfManagerId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_ChatId",
                table: "Accounts",
                column: "ChatId");

            migrationBuilder.CreateIndex(
                name: "IX_Chats_EfManagerId",
                table: "Chats",
                column: "EfManagerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Chats_ChatId",
                table: "Accounts",
                column: "ChatId",
                principalTable: "Chats",
                principalColumn: "ChatId");

            migrationBuilder.AddForeignKey(
                name: "FK_Annonces_Chats_ChatId",
                table: "Annonces",
                column: "ChatId",
                principalTable: "Chats",
                principalColumn: "ChatId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Chats_ChatId",
                table: "Messages",
                column: "ChatId",
                principalTable: "Chats",
                principalColumn: "ChatId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
