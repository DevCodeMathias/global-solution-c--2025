using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace exchangeHouse_api.Migrations
{
    /// <inheritdoc />
    public partial class AddUsersAndBenefitsRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: false),
                    Role = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkBenefits_User_Id",
                table: "WorkBenefits",
                column: "User_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkBenefits_User_User_Id",
                table: "WorkBenefits",
                column: "User_Id",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkBenefits_User_User_Id",
                table: "WorkBenefits");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropIndex(
                name: "IX_WorkBenefits_User_Id",
                table: "WorkBenefits");
        }
    }
}
