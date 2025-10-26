using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tourism_2._0.Migrations
{
    /// <inheritdoc />
    public partial class _init4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5ffeb146-ebc1-4f3c-8b76-a12213c739f2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7ea9f588-edc4-4bde-8ac2-939dea1c28b8", "AQAAAAIAAYagAAAAENTzdgckr6CoG/+VqpWwfIGHWA13v5YJDvDLL6o7RpuVsmklZsIhIr7pAZT5VEnY3w==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5ffeb146-ebc1-4f3c-8b76-a12213c739f2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7490be36-8960-40c9-b5ce-d1947c231932", "AQAAAAIAAYagAAAAEKzSmfs3CS1hPb/ooTUEMtlDG21ixLi0LJKMngS1bijWsQY370QrybC/jmAmsSBfOw==" });
        }
    }
}
