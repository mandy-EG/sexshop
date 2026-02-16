using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VelvetIvoryApi.Models;

namespace VelvetIvoryApi.Data;

public class AppDbContext : IdentityDbContext<AppUser>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Seed Roles
        var adminRoleId = "admin-role-id";
        var customerRoleId = "customer-role-id";

        var roles = new List<IdentityRole>
        {
            new IdentityRole
            {
                Id = adminRoleId,
                Name = "Admin",
                NormalizedName = "ADMIN"
            },
            new IdentityRole
            {
                Id = customerRoleId,
                Name = "Customer",
                NormalizedName = "CUSTOMER"
            }
        };

        builder.Entity<IdentityRole>().HasData(roles);

        // Seed Admin User
        var adminUserId = "admin-user-id";
        var adminUser = new AppUser
        {
            Id = adminUserId,
            UserName = "admin@velvet.com",
            Email = "admin@velvet.com",
            NormalizedUserName = "ADMIN@VELVET.COM",
            NormalizedEmail = "ADMIN@VELVET.COM",
            EmailConfirmed = true
        };

        var passwordHasher = new PasswordHasher<AppUser>();
        adminUser.PasswordHash = passwordHasher.HashPassword(adminUser, "Admin123!");

        builder.Entity<AppUser>().HasData(adminUser);

        // Assign Admin Role to Admin User
        builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
        {
            RoleId = adminRoleId,
            UserId = adminUserId
        });

        // Seed Products
        builder.Entity<Product>().HasData(
            new Product { Id = 1, Name = "Silk Kimono Robe", Description = "Luxurious 100% silk kimono robe in champagne gold.", Price = 129.99m, Stock = 15, Category = "Lingerie", ImageUrl = "https://images.unsplash.com/photo-1627916388484-934c26b4293f?auto=format&fit=crop&q=80&w=800" },
            new Product { Id = 2, Name = "Velvet Body Oil", Description = "Organic body oil infused with jasmine and vanilla.", Price = 45.00m, Stock = 50, Category = "Wellness", ImageUrl = "https://images.unsplash.com/photo-1615900119312-2acd3a71f3ad?auto=format&fit=crop&q=80&w=800" },
            new Product { Id = 3, Name = "Midnight Lace Set", Description = "Intricate black lace bralette and panty set.", Price = 85.50m, Stock = 20, Category = "Lingerie", ImageUrl = "https://images.unsplash.com/photo-1596482163618-20a20275ccca?auto=format&fit=crop&q=80&w=800" },
            new Product { Id = 4, Name = "Rose Quartz Massage Wand", Description = "Handcrafted rose quartz wand for facial or body massage.", Price = 35.00m, Stock = 30, Category = "Wellness", ImageUrl = "https://images.unsplash.com/photo-1616353329107-742eebe064c5?auto=format&fit=crop&q=80&w=800" },
            new Product { Id = 5, Name = "Satin Sleep Mask", Description = "Ultra-soft satin sleep mask for deep restorative rest.", Price = 25.00m, Stock = 100, Category = "Accessories", ImageUrl = "https://images.unsplash.com/photo-1517849845537-4d257902454a?auto=format&fit=crop&q=80&w=800" },
            new Product { Id = 6, Name = "Golden Ember Candle", Description = "Soy wax candle with notes of amber and sandalwood.", Price = 42.00m, Stock = 40, Category = "Wellness", ImageUrl = "https://images.unsplash.com/photo-1602826673327-1c463138f7bf?auto=format&fit=crop&q=80&w=800" },
            new Product { Id = 7, Name = "Pearl Bondage Rope", Description = "Elegant soft rope with faux pearl accents for aesthetic play.", Price = 55.00m, Stock = 15, Category = "Accessories", ImageUrl = "https://images.unsplash.com/photo-1612450630386-455b79698d28?auto=format&fit=crop&q=80&w=800" },
            new Product { Id = 8, Name = "Crystal Pleasure Wand", Description = "Glass pleasure wand designed for temperature play.", Price = 65.00m, Stock = 25, Category = "Toys", ImageUrl = "https://images.unsplash.com/photo-1563203369-26f2e4a5ccf7?auto=format&fit=crop&q=80&w=800" },
            new Product { Id = 9, Name = "Sheer Tulle Bodysuit", Description = "Minimalist sheer bodysuit with velvet piping.", Price = 95.00m, Stock = 12, Category = "Lingerie", ImageUrl = "https://images.unsplash.com/photo-1583846711818-b6d819ae6e10?auto=format&fit=crop&q=80&w=800" },
            new Product { Id = 10, Name = "Ivory Feather Fan", Description = "Handheld fan made with ethically sourced ostrich feathers.", Price = 75.00m, Stock = 8, Category = "Accessories", ImageUrl = "https://images.unsplash.com/photo-1595181788647-f3d65011684c?auto=format&fit=crop&q=80&w=800" },
            new Product { Id = 11, Name = "Noir Leather Handcuffs", Description = "Premium leather handcuffs with gold hardware.", Price = 80.00m, Stock = 20, Category = "Accessories", ImageUrl = "https://images.unsplash.com/photo-1506152983158-b4a74a01c721?auto=format&fit=crop&q=80&w=800" },
            new Product { Id = 12, Name = "Crimson Shibari Rope", Description = "Traditional jute rope dyed in deep crimson for bondage art.", Price = 40.00m, Stock = 35, Category = "Accessories", ImageUrl = "https://images.unsplash.com/photo-1589363066699-317eb8a24558?auto=format&fit=crop&q=80&w=800" },
            new Product { Id = 13, Name = "Gold Plated Anal Jewel", Description = "Luxurious stainless steel plug with a crystal base.", Price = 90.00m, Stock = 15, Category = "Toys", ImageUrl = "https://images.unsplash.com/photo-1615655406736-b37c4fabf923?auto=format&fit=crop&q=80&w=800" },
            new Product { Id = 14, Name = "Glass Dildo - Curved", Description = "Artisan glass dildo with ergonomic curve for G-spot stimulation.", Price = 110.00m, Stock = 10, Category = "Toys", ImageUrl = "https://images.unsplash.com/photo-1516975080664-ed2fc6a32937?auto=format&fit=crop&q=80&w=800" },
            new Product { Id = 15, Name = "Silk Blindfold", Description = "Pure black silk blindfold to heighten your senses.", Price = 30.00m, Stock = 50, Category = "Accessories", ImageUrl = "https://images.unsplash.com/photo-1509631179647-0177331693ae?auto=format&fit=crop&q=80&w=800" },
            new Product { Id = 16, Name = "Remote Control Egg", Description = "Discreet vibrating egg with long-range remote control.", Price = 75.00m, Stock = 25, Category = "Toys", ImageUrl = "https://images.unsplash.com/photo-1558553205-d143c7b80a6c?auto=format&fit=crop&q=80&w=800" },
            new Product { Id = 17, Name = "Lace Open-Cup Bra", Description = "Seductive open-cup bra featuring delicate floral lace.", Price = 65.00m, Stock = 18, Category = "Lingerie", ImageUrl = "https://images.unsplash.com/photo-1549487950-c81b67f185df?auto=format&fit=crop&q=80&w=800" },
            new Product { Id = 18, Name = "Leather Collar & Leash", Description = "Sophisticated collar with detachable leash for power play.", Price = 95.00m, Stock = 12, Category = "Accessories", ImageUrl = "https://images.unsplash.com/photo-1600609842388-3e44917dc9b6?auto=format&fit=crop&q=80&w=800" },
            new Product { Id = 19, Name = "Warming Massage Oil", Description = "Edible warming oil that heats up with breath.", Price = 38.00m, Stock = 40, Category = "Wellness", ImageUrl = "https://images.unsplash.com/photo-1608248597279-f99d160bfbc8?auto=format&fit=crop&q=80&w=800" },
            new Product { Id = 20, Name = "Feather Tickler", Description = "Ostrich feather tickler for teasing sensitive zones.", Price = 28.00m, Stock = 30, Category = "Accessories", ImageUrl = "https://images.unsplash.com/photo-1595181788647-f3d65011684c?auto=format&fit=crop&q=80&w=800" },
            new Product { Id = 21, Name = "Dual Action Rabbit", Description = "Premium silicone vibrator with dual stimulation motors.", Price = 140.00m, Stock = 20, Category = "Toys", ImageUrl = "https://images.unsplash.com/photo-1576426863848-c2185fc6e818?auto=format&fit=crop&q=80&w=800" },
            new Product { Id = 22, Name = "Noir Gag", Description = "Elegant silicone ball gag with adjustable leather strap.", Price = 55.00m, Stock = 15, Category = "Accessories", ImageUrl = "https://images.unsplash.com/photo-1591348276333-113843063e36?auto=format&fit=crop&q=80&w=800" },
            new Product { Id = 23, Name = "Glass Butt Plug Set", Description = "Set of 3 graduated glass plugs for anal exploration.", Price = 90.00m, Stock = 10, Category = "Toys", ImageUrl = "https://images.unsplash.com/photo-1533206485299-52e935496156?auto=format&fit=crop&q=80&w=800" },
            new Product { Id = 24, Name = "Sheer Bodystocking", Description = "Full body fishnet stocking for a daring reveal.", Price = 45.00m, Stock = 25, Category = "Lingerie", ImageUrl = "https://images.unsplash.com/photo-1595777457583-95e059d581b8?auto=format&fit=crop&q=80&w=800" },
            new Product { Id = 25, Name = "Gold Nipple Clamps", Description = "Adjustable clamps with gold chain connector.", Price = 32.00m, Stock = 20, Category = "Accessories", ImageUrl = "https://images.unsplash.com/photo-1621799754526-a0d52c49fad5?auto=format&fit=crop&q=80&w=800" },
            new Product { Id = 26, Name = "Prostate Massager", Description = "Ergonomically designed massager for deep satisfaction.", Price = 85.00m, Stock = 15, Category = "Toys", ImageUrl = "https://images.unsplash.com/photo-1582213782179-e0d53f98f2ca?auto=format&fit=crop&q=80&w=800" },
            new Product { Id = 27, Name = "Cordless Magic Wand", Description = "The ultimate power in a cordless, rechargeable wand.", Price = 120.00m, Stock = 20, Category = "Toys", ImageUrl = "https://images.unsplash.com/photo-1579453723368-233f2c5d5d83?auto=format&fit=crop&q=80&w=800" },
            new Product { Id = 28, Name = "Leather Spanking Paddle", Description = "Firm leather paddle for impact play enthusiasts.", Price = 50.00m, Stock = 18, Category = "Accessories", ImageUrl = "https://images.unsplash.com/photo-1600609842388-3e44917dc9b6?auto=format&fit=crop&q=80&w=800" },
            new Product { Id = 29, Name = "Crotchless Pearl Thong", Description = "Seductive thong featuring a strand of faux pearls.", Price = 35.00m, Stock = 25, Category = "Lingerie", ImageUrl = "https://images.unsplash.com/photo-1588117260148-447884962bc5?auto=format&fit=crop&q=80&w=800" },
            new Product { Id = 30, Name = "Sensation Wheel", Description = "Pinwheel for gentle sensory play and nerve stimulation.", Price = 20.00m, Stock = 40, Category = "Accessories", ImageUrl = "https://images.unsplash.com/photo-1632705971485-617d5225c57d?auto=format&fit=crop&q=80&w=800" }
        );
    }
}
