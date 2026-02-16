using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VelvetIvoryApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProductImages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin-user-id",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "74ef0608-4a93-4074-9bc7-fa4ba1bd1821", "AQAAAAIAAYagAAAAEKQelat9NjJB/V0nUgTRDaODG0XdmhCEihMElD/XYSe9F2Suff0Kckp32mOA7ljkbQ==", "2669713c-698e-40f8-a45c-1405cc90f2c3" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://images.unsplash.com/photo-1627916388484-934c26b4293f?auto=format&fit=crop&q=80&w=800");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "https://images.unsplash.com/photo-1615900119312-2acd3a71f3ad?auto=format&fit=crop&q=80&w=800");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "https://images.unsplash.com/photo-1596482163618-20a20275ccca?auto=format&fit=crop&q=80&w=800");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageUrl",
                value: "https://images.unsplash.com/photo-1616353329107-742eebe064c5?auto=format&fit=crop&q=80&w=800");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "ImageUrl",
                value: "https://images.unsplash.com/photo-1612450630386-455b79698d28?auto=format&fit=crop&q=80&w=800");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "Category",
                value: "Toys");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "ImageUrl",
                value: "https://images.unsplash.com/photo-1595181788647-f3d65011684c?auto=format&fit=crop&q=80&w=800");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "ImageUrl",
                value: "https://images.unsplash.com/photo-1506152983158-b4a74a01c721?auto=format&fit=crop&q=80&w=800");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "ImageUrl",
                value: "https://images.unsplash.com/photo-1589363066699-317eb8a24558?auto=format&fit=crop&q=80&w=800");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                column: "ImageUrl",
                value: "https://images.unsplash.com/photo-1549487950-c81b67f185df?auto=format&fit=crop&q=80&w=800");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                column: "ImageUrl",
                value: "https://images.unsplash.com/photo-1600609842388-3e44917dc9b6?auto=format&fit=crop&q=80&w=800");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 28,
                column: "ImageUrl",
                value: "https://images.unsplash.com/photo-1600609842388-3e44917dc9b6?auto=format&fit=crop&q=80&w=800");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin-user-id",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "10488c99-e765-45a0-8c4e-6bb43c349f8d", "AQAAAAIAAYagAAAAEPAL2aYFIWmXHbb5h0H8LpwzRZMQ9T3DRp1Y/+lJl4ZFJevta1PWV50qHp4iYO84zg==", "601d7afd-2d1e-40ac-bb31-d4ed2a2944f9" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://images.unsplash.com/photo-1596483758372-lba04c407d57?auto=format&fit=crop&q=80&w=800");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "https://images.unsplash.com/photo-1620916566398-39f1143ab7be?auto=format&fit=crop&q=80&w=800");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "https://images.unsplash.com/photo-1582716401301-b2407dc7563d?auto=format&fit=crop&q=80&w=800");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageUrl",
                value: "https://images.unsplash.com/photo-1616353328537-83344ea8e5f5?auto=format&fit=crop&q=80&w=800");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "ImageUrl",
                value: "https://images.unsplash.com/photo-1570701123927-41484ba332f1?auto=format&fit=crop&q=80&w=800");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "Category",
                value: "Wellness");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "ImageUrl",
                value: "https://images.unsplash.com/photo-1560159495-23c3109a1e96?auto=format&fit=crop&q=80&w=800");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "ImageUrl",
                value: "https://images.unsplash.com/photo-1621799754526-a0d52c49fad5?auto=format&fit=crop&q=80&w=800");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "ImageUrl",
                value: "https://images.unsplash.com/photo-1541963463532-d68292c34b19?auto=format&fit=crop&q=80&w=800");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                column: "ImageUrl",
                value: "https://images.unsplash.com/photo-1596483758372-lba04c407d57?auto=format&fit=crop&q=80&w=800");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                column: "ImageUrl",
                value: "https://images.unsplash.com/photo-1589363066699-317eb8a24558?auto=format&fit=crop&q=80&w=800");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 28,
                column: "ImageUrl",
                value: "https://images.unsplash.com/photo-1572569028738-411a56103324?auto=format&fit=crop&q=80&w=800");
        }
    }
}
