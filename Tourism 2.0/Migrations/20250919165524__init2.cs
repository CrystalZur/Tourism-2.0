using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tourism_2._0.Migrations
{
    /// <inheritdoc />
    public partial class _init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d6367c5f-bc93-4f1e-be83-90937a26a1db",
                column: "NormalizedName",
                value: "ADMIN");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5ffeb146-ebc1-4f3c-8b76-a12213c739f2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9c9e10f8-4f6f-4087-92d3-36220dc52b93", "AQAAAAIAAYagAAAAEH2b1dZyF3jwLK/tvSkeRzw9Kw0wTDhtJHojFWJOgSoCx2poo5VK5FUQf2H5mLf6VA==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d6367c5f-bc93-4f1e-be83-90937a26a1db",
                column: "NormalizedName",
                value: "D6367C5F-BC93-4F1E-BE83-90937A26A1DB");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5ffeb146-ebc1-4f3c-8b76-a12213c739f2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "491918cf-afa9-477d-b6cc-6233f790cc96", "AQAAAAIAAYagAAAAEFU+W4wyKhyW879Br/azn16et2+Ta9hcVzfsbSt//X6/eXozaewzvbCxVrWyTHBjnw==" });
        }
    }
}
