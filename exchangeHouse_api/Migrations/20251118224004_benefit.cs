using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace exchangeHouse_api.Migrations
{
    /// <inheritdoc />
    public partial class benefit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "WalletBalance",
                table: "Users",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "BenefitAcquisitionHistories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    BenefitId = table.Column<Guid>(type: "uuid", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    AmountSpent = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BenefitAcquisitionHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BenefitAcquisitionHistories_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BenefitAcquisitionHistories_WorkBenefits_BenefitId",
                        column: x => x.BenefitId,
                        principalTable: "WorkBenefits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BenefitAcquisitionHistories_BenefitId",
                table: "BenefitAcquisitionHistories",
                column: "BenefitId");

            migrationBuilder.CreateIndex(
                name: "IX_BenefitAcquisitionHistories_UserId",
                table: "BenefitAcquisitionHistories",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BenefitAcquisitionHistories");

            migrationBuilder.DropColumn(
                name: "WalletBalance",
                table: "Users");
        }
    }
}
