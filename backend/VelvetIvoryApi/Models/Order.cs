using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VelvetIvoryApi.Models;

public class Order
{
    public int Id { get; set; }
    
    [Required]
    public string UserId { get; set; } = string.Empty;
    
    [ForeignKey("UserId")]
    public AppUser? User { get; set; }
    
    public DateTime OrderDate { get; set; } = DateTime.UtcNow;
    
    [Column(TypeName = "decimal(18,2)")]
    public decimal TotalAmount { get; set; }
    
    public List<OrderItem> OrderItems { get; set; } = new();
}
