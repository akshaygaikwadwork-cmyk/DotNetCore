using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeFirstApproch_EntityFrame.Migrations
{
    public partial class codeFirstCreateDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_StudentUsingEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudName = table.Column<string>(type: "varchar(100)", nullable: false),
                    StudGender = table.Column<string>(type: "varchar(20)", nullable: false),
                    StudAge = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_StudentUsingEntity", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_StudentUsingEntity");
        }
    }
}
