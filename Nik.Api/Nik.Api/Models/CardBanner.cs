using System;
using System.Collections.Generic;

namespace Nik.Api.Models;

public partial class CardBanner
{
    public int CardBannerId { get; set; }

    public string Icon { get; set; } = null!;

    public string Title { get; set; } = null!;

    public string Text { get; set; } = null!;
}
