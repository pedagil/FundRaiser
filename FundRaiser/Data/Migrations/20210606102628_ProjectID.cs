using Microsoft.EntityFrameworkCore.Migrations;

namespace FundRaiser.Data.Migrations
{
    public partial class ProjectID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProjId",
                table: "Reward",
                newName: "ProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProjectId",
                table: "Reward",
                newName: "ProjId");
        }
    }
}
