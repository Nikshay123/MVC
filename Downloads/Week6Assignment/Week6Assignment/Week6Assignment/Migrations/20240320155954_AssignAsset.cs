using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Week6Assignment.Migrations
{
    /// <inheritdoc />
    public partial class AssignAsset : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AssetId",
                table: "Assign",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "AssetType",
                table: "Assign",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AssetId",
                table: "Assign");

            migrationBuilder.DropColumn(
                name: "AssetType",
                table: "Assign");
        }
    }
}
