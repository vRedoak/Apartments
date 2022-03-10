using Microsoft.EntityFrameworkCore.Migrations;
using System.IO;

namespace Apartments.Migrations
{
    public partial class AddHousingTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sql = File.ReadAllText(Path.Combine("Migrations", "SQL", "20220129162146_AddHousingTypes.sql"));
            migrationBuilder.Sql(sql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
