using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FundRaiser.Data.Migrations
{
    public partial class Reward_Backer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FundProject_Project_ProjectId",
                table: "FundProject");

            migrationBuilder.RenameColumn(
                name: "ProjectId",
                table: "FundProject",
                newName: "RewardId");

            migrationBuilder.RenameIndex(
                name: "IX_FundProject_ProjectId",
                table: "FundProject",
                newName: "IX_FundProject_RewardId");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Backer",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RegisterDate",
                table: "Backer",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_FundProject_Reward_RewardId",
                table: "FundProject",
                column: "RewardId",
                principalTable: "Reward",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FundProject_Reward_RewardId",
                table: "FundProject");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Backer");

            migrationBuilder.DropColumn(
                name: "RegisterDate",
                table: "Backer");

            migrationBuilder.RenameColumn(
                name: "RewardId",
                table: "FundProject",
                newName: "ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_FundProject_RewardId",
                table: "FundProject",
                newName: "IX_FundProject_ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_FundProject_Project_ProjectId",
                table: "FundProject",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
