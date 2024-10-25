using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cpm.Api.Inftrastructure.Migrations
{
    /// <inheritdoc />
    public partial class cpmModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clinic_master",
                columns: table => new
                {
                    ClinicId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsPasswordChange = table.Column<int>(type: "int", nullable: false),
                    IsApprove = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    InsBy = table.Column<int>(type: "int", nullable: false),
                    InsDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdBy = table.Column<int>(type: "int", nullable: false),
                    UpdDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clinic_master", x => x.ClinicId);
                });

            migrationBuilder.CreateTable(
                name: "Role_master",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role_master", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Skill_master",
                columns: table => new
                {
                    SkillId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    InsBy = table.Column<int>(type: "int", nullable: false),
                    InsDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdBy = table.Column<int>(type: "int", nullable: false),
                    UpdDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skill_master", x => x.SkillId);
                });

            migrationBuilder.CreateTable(
                name: "Login_Model",
                columns: table => new
                {
                    LoginId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    EmailId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Login_Model", x => x.LoginId);
                    table.ForeignKey(
                        name: "FK_Login_Model_Role_master_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role_master",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Doctor_master",
                columns: table => new
                {
                    DoctorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DoctorNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DoctorEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SkillId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    InsBy = table.Column<int>(type: "int", nullable: false),
                    InsDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdBy = table.Column<int>(type: "int", nullable: false),
                    UpdDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctor_master", x => x.DoctorId);
                    table.ForeignKey(
                        name: "FK_Doctor_master_Skill_master_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skill_master",
                        principalColumn: "SkillId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Doctor_master_SkillId",
                table: "Doctor_master",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_Login_Model_RoleId",
                table: "Login_Model",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clinic_master");

            migrationBuilder.DropTable(
                name: "Doctor_master");

            migrationBuilder.DropTable(
                name: "Login_Model");

            migrationBuilder.DropTable(
                name: "Skill_master");

            migrationBuilder.DropTable(
                name: "Role_master");
        }
    }
}
