using System;
using System.Collections.Generic;

namespace Nik.Api.Models;

public partial class Social
{
    public int SocialId { get; set; }

    public string Icon { get; set; } = null!;

    public string Url { get; set; } = null!;
}
