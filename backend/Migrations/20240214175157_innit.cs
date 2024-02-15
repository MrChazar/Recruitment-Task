using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    public partial class innit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DateCalculations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumberofOccurences = table.Column<int>(type: "int", nullable: false),
                    TodayDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstAppearance = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PreviousApperance = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NextApperance = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DateCalculations", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "DateCalculations",
                columns: new[] { "Id", "FirstAppearance", "NextApperance", "NumberofOccurences", "PreviousApperance", "TodayDate" },
                values: new object[] { 1, "2023-08-02", "2023-09-06", 5, "2023-08-30", "2023-09-01" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DateCalculations");
        }
    }
}
