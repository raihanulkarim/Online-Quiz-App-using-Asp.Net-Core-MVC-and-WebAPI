using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineQuizApi.Migrations
{
    public partial class initmigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Question = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Option1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Option2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Option3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Option4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CorrAns = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questions_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Title" },
                values: new object[] { 1, "C#" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Title" },
                values: new object[] { 2, "MsSQL" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Title" },
                values: new object[] { 3, "ASP.Net Core" });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "CategoryId", "CorrAns", "Option1", "Option2", "Option3", "Option4", "Question" },
                values: new object[,]
                {
                    { 1, 1, "C int a = 32; int b = 40;", "A int a = 32, b = 40.6;", "B int a = 42; b = 40;", "C int a = 32; int b = 40;", "D int a = b = 42;", "Correct Declaration of Values to variables a and b?" },
                    { 2, 1, "8", "8", "4", "2", "1", "How many Bytes are stored by Long Datatype in C# .net?" },
                    { 3, 2, "Data Manipulation Language(DML)", "Data Manipulation Language(DML)", "Data Definition Language(DDL)", "Both Of Above", "None", "Which Is The Subset Of SQL Commands Used To Manipulate Oracle Database Structures, Including Tables?" },
                    { 4, 2, "2345", "6789", "1234", "2345", "456789", "The SQL Statement<br>SELECT SUBSTR('123456789', INSTR('abcabcabc', 'b'), 4) FROM DUAL;" },
                    { 5, 3, "LCID", "LCID", "SessionId", "Key", "Item", "Which property of the session object is used to set the local identifier?" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Questions_CategoryId",
                table: "Questions",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
