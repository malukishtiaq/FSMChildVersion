using Microsoft.EntityFrameworkCore.Migrations;

namespace FSMChildVersion.MigrationBait.Migrations
{
    public partial class Migration13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsLogin",
                table: "User",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "SQId",
                table: "User",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "SQId",
                table: "MakeUp",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsLogin",
                table: "User");

            migrationBuilder.DropColumn(
                name: "SQId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "SQId",
                table: "MakeUp");
        }
    }
}
