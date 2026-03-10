using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DemoWebApp.Pages;

[Authorize]
public class ProductsModel : PageModel
{
    public List<Product> Products { get; } =
    [
        new(1, "Laptop Pro 15", "Electronics", 1299.99m, 45, 4.5),
        new(2, "Wireless Mouse", "Electronics", 29.99m, 150, 4.2),
        new(3, "Office Desk Chair", "Furniture", 349.99m, 30, 4.7),
        new(4, "USB-C Hub", "Electronics", 49.99m, 200, 4.0),
        new(5, "Standing Desk", "Furniture", 599.99m, 15, 4.8),
        new(6, "Mechanical Keyboard", "Electronics", 89.99m, 75, 4.6),
        new(7, "Monitor 27 inch", "Electronics", 399.99m, 60, 4.4),
        new(8, "Desk Lamp LED", "Accessories", 24.99m, 100, 4.1),
        new(9, "Webcam HD", "Electronics", 69.99m, 80, 4.3),
        new(10, "Notebook Set", "Stationery", 12.99m, 500, 3.9),
    ];

    public void OnGet() { }
}

public record Product(int Id, string Name, string Category, decimal Price, int Stock, double Rating);
