using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cpm.Api.Inftrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Add_DiagnosisTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Patient_Diagnosis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(type: "int", nullable: true),
                    VisitedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Report = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    prescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FoodSuggestions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsQueue = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient_Diagnosis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patient_Diagnosis_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "PatientId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Patient_Diagnosis_PatientId",
                table: "Patient_Diagnosis",
                column: "PatientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Patient_Diagnosis");
        }
    }
}
