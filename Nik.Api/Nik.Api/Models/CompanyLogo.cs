using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nik.Api.Models;

public partial class CompanyLogo
{
    public int CompanyLogosId { get; set; }

    public string ImageUrl { get; set; } = null!;
    [NotMapped]
    public IFormFile FormFile { get; set; }
}
