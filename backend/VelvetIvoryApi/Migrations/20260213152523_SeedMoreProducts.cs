using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VelvetIvoryApi.Migrations
{
    /// <inheritdoc />
    public partial class SeedMoreProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin-user-id",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4e2fc96a-360c-4aa9-aac5-da4b7f117f71", "AQAAAAIAAYagAAAAELjyNWGtx/vC3bvnHfYsOST21pYA9Ztcr9w4VxB+/dw5DILR6vw93xU807JBYky9WQ==", "ba0a51eb-f0d6-4449-a136-ee424774d768" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Description", "ImageUrl", "Name", "Price", "Stock" },
                values: new object[,]
                {
                    { 1, "Lingerie", "Luxurious 100% silk kimono robe in champagne gold.", "https://images.unsplash.com/photo-1596483758372-lba04c407d57?auto=format&fit=crop&q=80&w=800", "Silk Kimono Robe", 129.99m, 15 },
                    { 2, "Wellness", "Organic body oil infused with jasmine and vanilla.", "https://images.unsplash.com/photo-1620916566398-39f1143ab7be?auto=format&fit=crop&q=80&w=800", "Velvet Body Oil", 45.00m, 50 },
                    { 3, "Lingerie", "Intricate black lace bralette and panty set.", "https://images.unsplash.com/photo-1582716401301-b2407dc7563d?auto=format&fit=crop&q=80&w=800", "Midnight Lace Set", 85.50m, 20 },
                    { 4, "Wellness", "Handcrafted rose quartz wand for facial or body massage.", "https://images.unsplash.com/photo-1616353328537-83344ea8e5f5?auto=format&fit=crop&q=80&w=800", "Rose Quartz Massage Wand", 35.00m, 30 },
                    { 5, "Accessories", "Ultra-soft satin sleep mask for deep restorative rest.", "https://images.unsplash.com/photo-1517849845537-4d257902454a?auto=format&fit=crop&q=80&w=800", "Satin Sleep Mask", 25.00m, 100 },
                    { 6, "Wellness", "Soy wax candle with notes of amber and sandalwood.", "https://images.unsplash.com/photo-1602826673327-1c463138f7bf?auto=format&fit=crop&q=80&w=800", "Golden Ember Candle", 42.00m, 40 },
                    { 7, "Accessories", "Elegant soft rope with faux pearl accents for aesthetic play.", "https://images.unsplash.com/photo-1570701123927-41484ba332f1?auto=format&fit=crop&q=80&w=800", "Pearl Bondage Rope", 55.00m, 15 },
                    { 8, "Wellness", "Glass pleasure wand designed for temperature play.", "https://images.unsplash.com/photo-1563203369-26f2e4a5ccf7?auto=format&fit=crop&q=80&w=800", "Crystal Pleasure Wand", 65.00m, 25 },
                    { 9, "Lingerie", "Minimalist sheer bodysuit with velvet piping.", "https://images.unsplash.com/photo-1583846711818-b6d819ae6e10?auto=format&fit=crop&q=80&w=800", "Sheer Tulle Bodysuit", 95.00m, 12 },
                    { 10, "Accessories", "Handheld fan made with ethically sourced ostrich feathers.", "https://images.unsplash.com/photo-1560159495-23c3109a1e96?auto=format&fit=crop&q=80&w=800", "Ivory Feather Fan", 75.00m, 8 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin-user-id",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "81398111-6e4d-453f-94cc-6120c7942118", "AQAAAAIAAYagAAAAELl61lnajLPhB2Xtl+g9fzU9UUNQzCGsyJ5Yy3DWSaE6yeiBZKj5dxVcAwtXNcO+Rg==", "4039684d-f703-4767-8c6c-9982730755c6" });
        }
    }
}
