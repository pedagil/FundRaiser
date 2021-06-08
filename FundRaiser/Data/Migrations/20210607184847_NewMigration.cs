using Microsoft.EntityFrameworkCore.Migrations;

namespace FundRaiser.Data.Migrations
{
    public partial class NewMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RewardStatus",
                table: "Reward",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RewardStatus",
                table: "Reward");
        }
    }
}
