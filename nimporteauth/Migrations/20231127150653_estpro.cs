using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace nimporteauth.Migrations
{
    /// <inheritdoc />
    public partial class estpro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "estPro",
                table: "Contact",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "estPro",
                table: "Contact");
        }
    }
}
