using System;
using System.Collections.Generic;

namespace Nik.Api.Models;

public partial class ContactU
{
    public int ContactUsId { get; set; }

    public string Address { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Email { get; set; } = null!;
}
