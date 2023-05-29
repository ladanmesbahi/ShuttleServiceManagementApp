using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShuttleServiceManagementApp.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Added_TimingCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TimingCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimingCategories", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "UK_TimingCategory_Title",
                table: "TimingCategories",
                column: "Title",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TimingCategories");
        }
    }
}
