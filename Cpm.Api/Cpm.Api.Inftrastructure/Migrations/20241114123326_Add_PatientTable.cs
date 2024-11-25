using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cpm.Api.Inftrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Add_PatientTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Patient",
                columns: table => new
                {
                    PatientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MobileNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Weight = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Height = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SmokingOrNicotine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Physically_abled = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isDiabatice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClinicId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.PatientId);
                    table.ForeignKey(
                        name: "FK_Patient_Clinic_master_ClinicId",
                        column: x => x.ClinicId,
                        principalTable: "Clinic_master",
                        principalColumn: "ClinicId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Patient_ClinicId",
                table: "Patient",
                column: "ClinicId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Patient");
        }
    }
}
