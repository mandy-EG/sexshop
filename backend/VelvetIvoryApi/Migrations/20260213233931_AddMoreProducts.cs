using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VelvetIvoryApi.Migrations
{
    /// <inheritdoc />
    public partial class AddMoreProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin-user-id",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "10488c99-e765-45a0-8c4e-6bb43c349f8d", "AQAAAAIAAYagAAAAEPAL2aYFIWmXHbb5h0H8LpwzRZMQ9T3DRp1Y/+lJl4ZFJevta1PWV50qHp4iYO84zg==", "601d7afd-2d1e-40ac-bb31-d4ed2a2944f9" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Description", "ImageUrl", "Name", "Price", "Stock" },
                values: new object[,]
                {
                    { 11, "Accessories", "Premium leather handcuffs with gold hardware.", "https://images.unsplash.com/photo-1621799754526-a0d52c49fad5?auto=format&fit=crop&q=80&w=800", "Noir Leather Handcuffs", 80.00m, 20 },
                    { 12, "Accessories", "Traditional jute rope dyed in deep crimson for bondage art.", "https://images.unsplash.com/photo-1541963463532-d68292c34b19?auto=format&fit=crop&q=80&w=800", "Crimson Shibari Rope", 40.00m, 35 },
                    { 13, "Toys", "Luxurious stainless steel plug with a crystal base.", "https://images.unsplash.com/photo-1615655406736-b37c4fabf923?auto=format&fit=crop&q=80&w=800", "Gold Plated Anal Jewel", 90.00m, 15 },
                    { 14, "Toys", "Artisan glass dildo with ergonomic curve for G-spot stimulation.", "https://images.unsplash.com/photo-1516975080664-ed2fc6a32937?auto=format&fit=crop&q=80&w=800", "Glass Dildo - Curved", 110.00m, 10 },
                    { 15, "Accessories", "Pure black silk blindfold to heighten your senses.", "https://images.unsplash.com/photo-1509631179647-0177331693ae?auto=format&fit=crop&q=80&w=800", "Silk Blindfold", 30.00m, 50 },
                    { 16, "Toys", "Discreet vibrating egg with long-range remote control.", "https://images.unsplash.com/photo-1558553205-d143c7b80a6c?auto=format&fit=crop&q=80&w=800", "Remote Control Egg", 75.00m, 25 },
                    { 17, "Lingerie", "Seductive open-cup bra featuring delicate floral lace.", "https://images.unsplash.com/photo-1596483758372-lba04c407d57?auto=format&fit=crop&q=80&w=800", "Lace Open-Cup Bra", 65.00m, 18 },
                    { 18, "Accessories", "Sophisticated collar with detachable leash for power play.", "https://images.unsplash.com/photo-1589363066699-317eb8a24558?auto=format&fit=crop&q=80&w=800", "Leather Collar & Leash", 95.00m, 12 },
                    { 19, "Wellness", "Edible warming oil that heats up with breath.", "https://images.unsplash.com/photo-1608248597279-f99d160bfbc8?auto=format&fit=crop&q=80&w=800", "Warming Massage Oil", 38.00m, 40 },
                    { 20, "Accessories", "Ostrich feather tickler for teasing sensitive zones.", "https://images.unsplash.com/photo-1595181788647-f3d65011684c?auto=format&fit=crop&q=80&w=800", "Feather Tickler", 28.00m, 30 },
                    { 21, "Toys", "Premium silicone vibrator with dual stimulation motors.", "https://images.unsplash.com/photo-1576426863848-c2185fc6e818?auto=format&fit=crop&q=80&w=800", "Dual Action Rabbit", 140.00m, 20 },
                    { 22, "Accessories", "Elegant silicone ball gag with adjustable leather strap.", "https://images.unsplash.com/photo-1591348276333-113843063e36?auto=format&fit=crop&q=80&w=800", "Noir Gag", 55.00m, 15 },
                    { 23, "Toys", "Set of 3 graduated glass plugs for anal exploration.", "https://images.unsplash.com/photo-1533206485299-52e935496156?auto=format&fit=crop&q=80&w=800", "Glass Butt Plug Set", 90.00m, 10 },
                    { 24, "Lingerie", "Full body fishnet stocking for a daring reveal.", "https://images.unsplash.com/photo-1595777457583-95e059d581b8?auto=format&fit=crop&q=80&w=800", "Sheer Bodystocking", 45.00m, 25 },
                    { 25, "Accessories", "Adjustable clamps with gold chain connector.", "https://images.unsplash.com/photo-1621799754526-a0d52c49fad5?auto=format&fit=crop&q=80&w=800", "Gold Nipple Clamps", 32.00m, 20 },
                    { 26, "Toys", "Ergonomically designed massager for deep satisfaction.", "https://images.unsplash.com/photo-1582213782179-e0d53f98f2ca?auto=format&fit=crop&q=80&w=800", "Prostate Massager", 85.00m, 15 },
                    { 27, "Toys", "The ultimate power in a cordless, rechargeable wand.", "https://images.unsplash.com/photo-1579453723368-233f2c5d5d83?auto=format&fit=crop&q=80&w=800", "Cordless Magic Wand", 120.00m, 20 },
                    { 28, "Accessories", "Firm leather paddle for impact play enthusiasts.", "https://images.unsplash.com/photo-1572569028738-411a56103324?auto=format&fit=crop&q=80&w=800", "Leather Spanking Paddle", 50.00m, 18 },
                    { 29, "Lingerie", "Seductive thong featuring a strand of faux pearls.", "https://images.unsplash.com/photo-1588117260148-447884962bc5?auto=format&fit=crop&q=80&w=800", "Crotchless Pearl Thong", 35.00m, 25 },
                    { 30, "Accessories", "Pinwheel for gentle sensory play and nerve stimulation.", "https://images.unsplash.com/photo-1632705971485-617d5225c57d?auto=format&fit=crop&q=80&w=800", "Sensation Wheel", 20.00m, 40 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin-user-id",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f8231a2f-4e62-40b5-a0dd-166e9385216e", "AQAAAAIAAYagAAAAEAqP0uW9uUxPIehWRDV7pY/PAVk9OC0seEjS+pL0oRebW1QrRN20nnOPBG9fRsWYTA==", "eab453a7-d1e7-4806-a2fb-697706d35574" });
        }
    }
}
