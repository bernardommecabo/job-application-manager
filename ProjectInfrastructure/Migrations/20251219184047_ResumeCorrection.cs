using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectInfrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ResumeCorrection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Resume",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Resume");
        }
    }
}
