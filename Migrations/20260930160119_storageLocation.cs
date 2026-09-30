using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace combineDaySixteenN_TierAPIs.Migrations
{
    /// <inheritdoc />
    public partial class storageLocation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StorageLocation",
                table: "Supplies",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StorageLocation",
                table: "Supplies");
        }
    }
}
