using Microsoft.EntityFrameworkCore.Migrations;

namespace Midas_Data.Migrations
{
    public partial class MonthlyExpense_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MonthlyExpense",
                columns: table => new
                {
                    MonthlyExpenseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BillName = table.Column<string>(nullable: false),
                    BillAmount = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonthlyExpense", x => x.MonthlyExpenseId);
                });
        }

    }
}
