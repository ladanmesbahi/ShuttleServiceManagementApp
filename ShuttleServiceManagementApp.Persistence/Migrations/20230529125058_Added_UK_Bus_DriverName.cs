using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShuttleServiceManagementApp.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Added_UK_Bus_DriverName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "UK_Bus_DriverName",
                table: "Buses",
                column: "DriverName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "UK_Bus_DriverName",
                table: "Buses");
        }
    }
}
