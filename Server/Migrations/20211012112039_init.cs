using Microsoft.EntityFrameworkCore.Migrations;

namespace DockerTraining.Server.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsComplete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "IsComplete", "Title" },
                values: new object[,]
                {
                    { 1, false, "Wash clothes" },
                    { 2, true, "Get Coffee" },
                    { 3, false, "Call Dr Stone" },
                    { 4, false, "Buy Flowers for wife" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");
        }
    }
}
