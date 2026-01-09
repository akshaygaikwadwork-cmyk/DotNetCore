using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CQRS_DesignPrin_WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class initial_migration_For_EMployee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_EmployeeNew",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "Varchar(100)", nullable: false),
                    Address = table.Column<string>(type: "Varchar(300)", nullable: false),
                    Email = table.Column<string>(type: "Varchar(100)", nullable: false),
                    Phone = table.Column<string>(type: "Varchar(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_EmployeeNew", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_EmployeeNew");
        }
    }
}
