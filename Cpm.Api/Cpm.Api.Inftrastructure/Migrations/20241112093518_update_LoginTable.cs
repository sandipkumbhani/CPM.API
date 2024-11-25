using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cpm.Api.Inftrastructure.Migrations
{
    /// <inheritdoc />
    public partial class update_LoginTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Login_Model");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Login_Model",
                type: "int",
                nullable: true);
        }
    }
}
