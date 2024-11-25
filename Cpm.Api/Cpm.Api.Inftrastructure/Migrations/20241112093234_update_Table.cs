using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cpm.Api.Inftrastructure.Migrations
{
    /// <inheritdoc />
    public partial class update_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClinicId",
                table: "Doctor_master",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "Doctor_master",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Doctor_master_ClinicId",
                table: "Doctor_master",
                column: "ClinicId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctor_master_RoleId",
                table: "Doctor_master",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctor_master_Clinic_master_ClinicId",
                table: "Doctor_master",
                column: "ClinicId",
                principalTable: "Clinic_master",
                principalColumn: "ClinicId");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctor_master_Role_master_RoleId",
                table: "Doctor_master",
                column: "RoleId",
                principalTable: "Role_master",
                principalColumn: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctor_master_Clinic_master_ClinicId",
                table: "Doctor_master");

            migrationBuilder.DropForeignKey(
                name: "FK_Doctor_master_Role_master_RoleId",
                table: "Doctor_master");

            migrationBuilder.DropIndex(
                name: "IX_Doctor_master_ClinicId",
                table: "Doctor_master");

            migrationBuilder.DropIndex(
                name: "IX_Doctor_master_RoleId",
                table: "Doctor_master");

            migrationBuilder.DropColumn(
                name: "ClinicId",
                table: "Doctor_master");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "Doctor_master");
        }
    }
}
