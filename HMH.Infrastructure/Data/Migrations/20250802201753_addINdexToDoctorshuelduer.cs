using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HMH.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class addINdexToDoctorshuelduer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_doctorSchedules_DoctorId",
                table: "doctorSchedules");

            migrationBuilder.CreateIndex(
                name: "IX_doctorSchedules_DoctorId_DayOfWeek",
                table: "doctorSchedules",
                columns: new[] { "DoctorId", "DayOfWeek" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_doctorSchedules_DoctorId_DayOfWeek",
                table: "doctorSchedules");

            migrationBuilder.CreateIndex(
                name: "IX_doctorSchedules_DoctorId",
                table: "doctorSchedules",
                column: "DoctorId");
        }
    }
}
