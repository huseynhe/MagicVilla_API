using Microsoft.EntityFrameworkCore.Migrations;

namespace MagicVilla_VillaAPI.Migrations
{
    public partial class addUserToDB2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserNam",
                table: "LocalUsers",
                newName: "UserName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "LocalUsers",
                newName: "UserNam");
        }
    }
}
