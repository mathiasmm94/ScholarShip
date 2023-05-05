using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ModelsApi.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    EfAccountId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: false),
                    PwHash = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    ChatId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.EfAccountId);
                });

            migrationBuilder.CreateTable(
                name: "Managers",
                columns: table => new
                {
                    EfManagerId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EfAccountId = table.Column<long>(type: "bigint", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Managers", x => x.EfManagerId);
                    table.ForeignKey(
                        name: "FK_Managers_Accounts_EfAccountId",
                        column: x => x.EfAccountId,
                        principalTable: "Accounts",
                        principalColumn: "EfAccountId",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "Annonces",
                columns: table => new
                {
                    AnnonceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Titel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kategori = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Beskrivelse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Studieretning = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BilledeSti = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EfManagerId = table.Column<long>(type: "bigint", nullable: false),
                    Stand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChatId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Annonces", x => x.AnnonceId);
                    table.ForeignKey(
                        name: "FK_Annonces_Chats_ChatId",
                        column: x => x.ChatId,
                        principalTable: "Chats",
                        principalColumn: "ChatId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Annonces_Managers_EfManagerId",
                        column: x => x.EfManagerId,
                        principalTable: "Managers",
                        principalColumn: "EfManagerId");
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    MessageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Messages = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChatId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.MessageId);
                    table.ForeignKey(
                        name: "FK_Messages_Chats_ChatId",
                        column: x => x.ChatId,
                        principalTable: "Chats",
                        principalColumn: "ChatId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_ChatId",
                table: "Accounts",
                column: "ChatId");

            migrationBuilder.CreateIndex(
                name: "IX_Annonces_ChatId",
                table: "Annonces",
                column: "ChatId");

            migrationBuilder.CreateIndex(
                name: "IX_Annonces_EfManagerId",
                table: "Annonces",
                column: "EfManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Chats_EfManagerId",
                table: "Chats",
                column: "EfManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Managers_EfAccountId",
                table: "Managers",
                column: "EfAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Managers_Email",
                table: "Managers",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ChatId",
                table: "Messages",
                column: "ChatId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Chats_ChatId",
                table: "Accounts",
                column: "ChatId",
                principalTable: "Chats",
                principalColumn: "ChatId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Chats_ChatId",
                table: "Accounts");

            migrationBuilder.DropTable(
                name: "Annonces");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Chats");

            migrationBuilder.DropTable(
                name: "Managers");

            migrationBuilder.DropTable(
                name: "Accounts");
        }
    }
}
