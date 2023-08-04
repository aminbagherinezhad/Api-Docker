using System;
using System.Collections.Generic;

namespace Nik.Api.Models;

public partial class User
{
    public int UserId { get; set; }

    public string Email { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public bool IsAdmin { get; set; }
}
