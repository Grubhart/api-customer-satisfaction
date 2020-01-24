using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace api_customer_satisfaction.Migrations
{
    public partial class apicustomersatisfactionModelsContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Evaluations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(maxLength: 100, nullable: false),
                    FirstName = table.Column<string>(maxLength: 200, nullable: true),
                    LastName = table.Column<string>(maxLength: 200, nullable: true),
                    Qualification = table.Column<int>(nullable: false),
                    EvaluationDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evaluations", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Evaluations",
                columns: new[] { "Id", "Email", "EvaluationDate", "FirstName", "LastName", "Qualification" },
                values: new object[] { 1, "ryesquen@gmail.com", new DateTime(2019, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Renzo", "Yesquén Herrera", 10 });

            migrationBuilder.InsertData(
                table: "Evaluations",
                columns: new[] { "Id", "Email", "EvaluationDate", "FirstName", "LastName", "Qualification" },
                values: new object[] { 2, "nayeska.gonzales@gmail.com", new DateTime(2019, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nayeska", "Gonzales Mauricio", 5 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Evaluations");
        }
    }
}
