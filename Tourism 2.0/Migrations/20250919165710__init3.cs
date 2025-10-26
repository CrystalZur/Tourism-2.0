using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tourism_2._0.Migrations
{
    /// <inheritdoc />
    public partial class _init3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5ffeb146-ebc1-4f3c-8b76-a12213c739f2",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash" },
                values: new object[] { "7490be36-8960-40c9-b5ce-d1947c231932", "ADMIN", "AQAAAAIAAYagAAAAEKzSmfs3CS1hPb/ooTUEMtlDG21ixLi0LJKMngS1bijWsQY370QrybC/jmAmsSBfOw==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5ffeb146-ebc1-4f3c-8b76-a12213c739f2",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash" },
                values: new object[] { "9c9e10f8-4f6f-4087-92d3-36220dc52b93", "5FFEB146-EBC1-4F3C-8B76-A12213C739F2", "AQAAAAIAAYagAAAAEH2b1dZyF3jwLK/tvSkeRzw9Kw0wTDhtJHojFWJOgSoCx2poo5VK5FUQf2H5mLf6VA==" });
        }
    }
}
