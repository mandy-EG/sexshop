using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VelvetIvoryApi.Data;
using VelvetIvoryApi.Dtos;
using VelvetIvoryApi.Models;

namespace VelvetIvoryApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class OrdersController : ControllerBase
{
    private readonly AppDbContext _context;

    public OrdersController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<ActionResult<OrderResponseDto>> CreateOrder(CreateOrderDto orderDto)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (userId == null) return Unauthorized();

        if (orderDto.Items == null || !orderDto.Items.Any())
            return BadRequest("Order must contain items");

        var order = new Order
        {
            UserId = userId,
            OrderDate = DateTime.UtcNow,
            OrderItems = new List<OrderItem>()
        };

        decimal totalAmount = 0;

        foreach (var itemDto in orderDto.Items)
        {
            var product = await _context.Products.FindAsync(itemDto.ProductId);
            if (product == null)
                return BadRequest($"Product with ID {itemDto.ProductId} not found");

            if (product.Stock < itemDto.Quantity)
                return BadRequest($"Insufficient stock for product {product.Name}");

            // Deduct stock
            product.Stock -= itemDto.Quantity;
            
            var orderItem = new OrderItem
            {
                ProductId = itemDto.ProductId,
                Quantity = itemDto.Quantity,
                Price = product.Price
            };
            
            order.OrderItems.Add(orderItem);
            totalAmount += product.Price * itemDto.Quantity;
        }

        order.TotalAmount = totalAmount;

        _context.Orders.Add(order);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetOrders), new { id = order.Id }, new OrderResponseDto
        {
            Id = order.Id,
            OrderDate = order.OrderDate,
            TotalAmount = order.TotalAmount
        });
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<OrderResponseDto>>> GetOrders()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        
        var orders = await _context.Orders
            .Where(o => o.UserId == userId)
            .OrderByDescending(o => o.OrderDate)
            .Select(o => new OrderResponseDto
            {
                Id = o.Id,
                OrderDate = o.OrderDate,
                TotalAmount = o.TotalAmount
            })
            .ToListAsync();

        return orders;
    }
}
