using System;
using System.Collections.Generic;

namespace WebApplication13.Models;

public partial class Product
{
    public int Id { get; set; }

    public string? ProductName { get; set; }

    public string? Description { get; set; }

    public long? Price { get; set; }

    public int? CategoryId { get; set; }

    public string? ProductImage { get; set; }

    public virtual Category? Category { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
