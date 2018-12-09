using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStack.Data.Migrations
{
    public partial class ChangedTheColumnSizeForProductType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ProductTypeName",
                table: "ProductTypes",
                type: "varchar(200)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar",
                oldMaxLength: 100);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ProductTypeName",
                table: "ProductTypes",
                type: "varchar",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldMaxLength: 100);
        }
    }
}
