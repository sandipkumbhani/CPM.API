using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cpm.Api.Inftrastructure.Migrations
{
    /// <inheritdoc />
    public partial class update_Logintbl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DoctorId",
                table: "Login_Model",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Login_Model_DoctorId",
                table: "Login_Model",
                column: "DoctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Login_Model_Doctor_master_DoctorId",
                table: "Login_Model",
                column: "DoctorId",
                principalTable: "Doctor_master",
                principalColumn: "DoctorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Login_Model_Doctor_master_DoctorId",
                table: "Login_Model");

            migrationBuilder.DropIndex(
                name: "IX_Login_Model_DoctorId",
                table: "Login_Model");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "Login_Model");
        }
    }
}
