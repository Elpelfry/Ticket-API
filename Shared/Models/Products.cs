
using System.ComponentModel.DataAnnotations;

namespace Shared.Models;

public class Products
{
    [Key]
    public int ProductId { get; set; }
    public string? Title { get; set; }
    public double Price { get; set; }
    public int Units { get; set; }
    public string? Description { get; set; }
    public double Discount { get; set; }
}