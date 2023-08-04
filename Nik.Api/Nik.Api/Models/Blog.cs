using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nik.Api.Models;

public partial class Blog
{
    public int BlogId { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Text { get; set; } = null!;

    public string ImageName { get; set; } = null!;

    public DateTime DateTime { get; set; }

    public string? Tags { get; set; }
    [NotMapped]
    public IFormFile FormFile { get; set; }
}
