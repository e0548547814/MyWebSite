﻿using System;
using System.Collections.Generic;

namespace Entity;

public partial class Product
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public decimal? Price { get; set; }

    public int CategoryId { get; set; }

    public string? Descriptions { get; set; }
    public string? Image { get; set; } = null;

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<OrderItem> OrderItems { get; set; } = 
        new List<OrderItem>();
}
