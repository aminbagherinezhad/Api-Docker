using System;
using System.Collections.Generic;

namespace Nik.Api.Models;

public partial class Contact
{
    public int ContactId { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Subject { get; set; } = null!;

    public string Text { get; set; } = null!;
}
