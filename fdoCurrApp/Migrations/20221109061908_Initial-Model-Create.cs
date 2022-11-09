using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fdoCurrApp.Migrations
{
    public partial class InitialModelCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
         

            migrationBuilder.CreateTable(
              name: "lecturerInfo",
              columns: table => new
              {
                  lec_id = table.Column<int>(type: "int", nullable: false),
                  fdo_id = table.Column<int>(type: "int", nullable: false),
                  lec_name = table.Column<string>(type: "nvarchar(128)", nullable: false),
                  lec_surname = table.Column<string>(type: "nvarchar(128)", nullable: false),
                  lec_pass = table.Column<string>(type: "nvarchar(32)", nullable: false),
                  auth_key = table.Column<string>(type: "nvarchar(128)", nullable: true),
                  time = table.Column<int>(type: "int", nullable: false),


              },
              constraints: table =>
              {
                  table.PrimaryKey("PK_lecturerInfo", x => new { x.lec_id });
                  table.ForeignKey(
                      name: "FK_lecturerInfo",
                      column: x => x.fdo_id,
                      principalTable: "fdo",
                      principalColumn: "id");
              });

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
               name: "lecturerInfo");
        }
    }
}
