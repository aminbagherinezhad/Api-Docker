﻿using System;
using System.Collections.Generic;

namespace Nik.Api.Models;

public partial class Category
{
    public int CategoryId { get; set; }

    public string Title { get; set; } = null!;

    public int? ParentId { get; set; }

    public virtual ICollection<CategoryImage> CategoryImages { get; set; } = new List<CategoryImage>();

    public virtual ICollection<Category> InverseParent { get; set; } = new List<Category>();

    public virtual Category? Parent { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
