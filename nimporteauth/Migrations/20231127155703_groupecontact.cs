using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace nimporteauth.Migrations
{
    /// <inheritdoc />
    public partial class groupecontact : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
