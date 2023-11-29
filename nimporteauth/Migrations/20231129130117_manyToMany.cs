using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace nimporteauth.Migrations
{
    /// <inheritdoc />
    public partial class manyToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contact_Groupe_groupeId",
                table: "Contact");

            migrationBuilder.DropIndex(
                name: "IX_Contact_groupeId",
                table: "Contact");

            migrationBuilder.DropColumn(
                name: "groupeId",
                table: "Contact");

            migrationBuilder.CreateTable(
                name: "ContactGroupe",
                columns: table => new
                {
                    GroupeId = table.Column<int>(type: "int", nullable: false),
                    ContactId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactGroupe", x => new { x.ContactId, x.GroupeId });
                    table.ForeignKey(
                        name: "FK_ContactGroupe_Contact_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contact",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContactGroupe_Groupe_GroupeId",
                        column: x => x.GroupeId,
                        principalTable: "Groupe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ContactGroupe_GroupeId",
                table: "ContactGroupe",
                column: "GroupeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactGroupe");

            migrationBuilder.AddColumn<int>(
                name: "groupeId",
                table: "Contact",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contact_groupeId",
                table: "Contact",
                column: "groupeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contact_Groupe_groupeId",
                table: "Contact",
                column: "groupeId",
                principalTable: "Groupe",
                principalColumn: "Id");
        }
    }
}
