using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewBlog.Migrations
{
    /// <inheritdoc />
    public partial class AdicionadoCampoGithub : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Github",
                table: "User",
                type: "VARCHAR(80)",
                maxLength: 80,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdateDate",
                table: "Post",
                type: "SMALLDATETIME",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 12, 23, 45, 25, 912, DateTimeKind.Utc).AddTicks(6466),
                oldClrType: typeof(DateTime),
                oldType: "SMALLDATETIME",
                oldDefaultValue: new DateTime(2024, 2, 12, 23, 25, 42, 202, DateTimeKind.Utc).AddTicks(5996));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Github",
                table: "User");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdateDate",
                table: "Post",
                type: "SMALLDATETIME",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 12, 23, 25, 42, 202, DateTimeKind.Utc).AddTicks(5996),
                oldClrType: typeof(DateTime),
                oldType: "SMALLDATETIME",
                oldDefaultValue: new DateTime(2024, 2, 12, 23, 45, 25, 912, DateTimeKind.Utc).AddTicks(6466));
        }
    }
}
