using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HMH.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class EditPatientNamePrpertyToNull1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PatientName",
                table: "Appointments",
                type: "nvarchar(max)",  // أو نوع العمود اللي تستخدمه
                nullable: true,         // تسمح بالقيم null
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PatientName",
                table: "Appointments",
                type: "nvarchar(max)",
                nullable: false,        // تعيد العمود لعدم السماح بـ null
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
