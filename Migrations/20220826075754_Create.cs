using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReactProjectGym.Migrations
{
    /// <inheritdoc />
    public partial class Create : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfileImage",
                table: "userDataModels");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProfileImage",
                table: "userDataModels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
