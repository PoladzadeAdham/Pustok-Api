using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pustok.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedDatas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Professions",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("99b14a9d-6c81-4790-aa19-f9085ba4c2b5"), "Default profession" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Professions",
                keyColumn: "Id",
                keyValue: new Guid("99b14a9d-6c81-4790-aa19-f9085ba4c2b5"));
        }
    }
}
