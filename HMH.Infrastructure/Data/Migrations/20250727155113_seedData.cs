using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HMH.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class seedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "clinics",
                columns: new[] { "Id", "Image", "Name" },
                values: new object[] { 1, "testImage", "Test" });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "ClinicsId", "ClinicsId1", "Description", "Experience", "Image", "Name", "Specialty" },
                values: new object[] { 1, 1, null, "test", 10, "test", "test", "test" });

            migrationBuilder.InsertData(
                table: "doctorSchedules",
                columns: new[] { "Id", "DayOfWeek", "DoctorId", "EndTime", "MaxAppointmentsPerDay", "StartTime" },
                values: new object[] { 1, 1, 1, new TimeSpan(0, 11, 0, 0, 0), 50, new TimeSpan(0, 5, 0, 0, 0) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "doctorSchedules",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "clinics",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
