using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeFirstApproch_EntityFrame.Migrations
{
    public partial class fornewcolumnStandard : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StudStandard",
                table: "tbl_StudentUsingEntity",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StudStandard",
                table: "tbl_StudentUsingEntity");
        }
    }
}
