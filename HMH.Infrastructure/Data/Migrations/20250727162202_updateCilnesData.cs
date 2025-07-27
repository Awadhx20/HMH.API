using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HMH.Infrastructure.Date.Migrations
{
    /// <inheritdoc />
    public partial class updateCilnesData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_clinics_ClinicsId1",
                table: "Doctors");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_ClinicsId1",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "ClinicsId1",
                table: "Doctors");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClinicsId1",
                table: "Doctors",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 1,
                column: "ClinicsId1",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_ClinicsId1",
                table: "Doctors",
                column: "ClinicsId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_clinics_ClinicsId1",
                table: "Doctors",
                column: "ClinicsId1",
                principalTable: "clinics",
                principalColumn: "Id");
        }
    }
}
