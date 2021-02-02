using Microsoft.EntityFrameworkCore.Migrations;

namespace ToDoAPI.Migrations
{
    public partial class MigrationN : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "TagId",
                table: "Tasks");

            migrationBuilder.InsertData(
                table: "TagTask",
                columns: new[] { "TagId", "TaskId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TagTask",
                keyColumns: new[] { "TagId", "TaskId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "TagTask",
                keyColumns: new[] { "TagId", "TaskId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "TagTask",
                keyColumns: new[] { "TagId", "TaskId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.AddColumn<int>(
                name: "TagId",
                table: "Tasks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 2, "In progress" },
                    { 3, "Completed" }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "High priority" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                column: "TagId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2,
                column: "TagId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3,
                column: "TagId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 4,
                column: "TagId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 5,
                column: "TagId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 6,
                column: "TagId",
                value: 1);
        }
    }
}
