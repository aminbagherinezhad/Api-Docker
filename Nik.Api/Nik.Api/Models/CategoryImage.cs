using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nik.Api.Models;

public partial class CategoryImage
{
    public int CategoryImageId { get; set; }

    public string ImageName { get; set; } = null!;

    public int CategoryId { get; set; }
    [NotMapped]
    public IFormFile FormFile { get; set; }
    public virtual Category Category { get; set; } = null!;
}
