using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Webapi.HealthClinic.tarde.Migrations
{
    /// <inheritdoc />
    public partial class Bd_v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Medico_CRM",
                table: "Medico");

            migrationBuilder.AlterColumn<string>(
                name: "CRM",
                table: "Medico",
                type: "VARCHAR(14)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "VARCHAR(14)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Medico_CRM",
                table: "Medico",
                column: "CRM",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Medico_CRM",
                table: "Medico");

            migrationBuilder.AlterColumn<string>(
                name: "CRM",
                table: "Medico",
                type: "VARCHAR(14)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(14)");

            migrationBuilder.CreateIndex(
                name: "IX_Medico_CRM",
                table: "Medico",
                column: "CRM",
                unique: true,
                filter: "[CRM] IS NOT NULL");
        }
    }
}
