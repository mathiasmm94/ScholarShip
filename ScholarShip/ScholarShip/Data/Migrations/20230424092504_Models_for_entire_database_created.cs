using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScholarShip.Data.Migrations
{
    /// <inheritdoc />
    public partial class Models_for_entire_database_created : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EfterNavn",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ForNavn",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Chats",
                columns: table => new
                {
                    ChatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chats", x => x.ChatId);
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
                    ProfileId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Stand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChatId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Annonces", x => x.AnnonceId);
                    table.ForeignKey(
                        name: "FK_Annonces_AspNetUsers_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Annonces_Chats_ChatId",
                        column: x => x.ChatId,
                        principalTable: "Chats",
                        principalColumn: "ChatId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChatProfil",
                columns: table => new
                {
                    ChatsChatId = table.Column<int>(type: "int", nullable: false),
                    ProfilsId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatProfil", x => new { x.ChatsChatId, x.ProfilsId });
                    table.ForeignKey(
                        name: "FK_ChatProfil_AspNetUsers_ProfilsId",
                        column: x => x.ProfilsId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChatProfil_Chats_ChatsChatId",
                        column: x => x.ChatsChatId,
                        principalTable: "Chats",
                        principalColumn: "ChatId",
                        onDelete: ReferentialAction.Cascade);
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
                name: "IX_Annonces_ChatId",
                table: "Annonces",
                column: "ChatId");

            migrationBuilder.CreateIndex(
                name: "IX_Annonces_ProfileId",
                table: "Annonces",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatProfil_ProfilsId",
                table: "ChatProfil",
                column: "ProfilsId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ChatId",
                table: "Messages",
                column: "ChatId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Annonces");

            migrationBuilder.DropTable(
                name: "ChatProfil");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Chats");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "EfterNavn",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ForNavn",
                table: "AspNetUsers");
        }
    }
}
