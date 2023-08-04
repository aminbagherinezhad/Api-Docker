using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nik.Api.Models;

public partial class Slider
{
    public int SliderId { get; set; }

    public string ImageName { get; set; } = null!;

    public string? FirstTitle { get; set; }

    public string MiddleTitle { get; set; } = null!;

    public string? FinalTitle { get; set; }
    [NotMapped]
    public IFormFile FormFile { get; set; }
}
