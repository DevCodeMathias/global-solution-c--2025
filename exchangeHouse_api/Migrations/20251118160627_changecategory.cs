using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace exchangeHouse_api.Migrations
{
    /// <inheritdoc />
    public partial class changecategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkBenefits_Users_UserId",
                table: "WorkBenefits");

            migrationBuilder.DropColumn(
                name: "User_Id",
                table: "WorkBenefits");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "WorkBenefits",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Category",
                table: "WorkBenefits",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkBenefits_Users_UserId",
                table: "WorkBenefits",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkBenefits_Users_UserId",
                table: "WorkBenefits");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "WorkBenefits",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "Category",
                table: "WorkBenefits",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "User_Id",
                table: "WorkBenefits",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkBenefits_Users_UserId",
                table: "WorkBenefits",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
