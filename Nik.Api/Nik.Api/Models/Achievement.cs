using System;
using System.Collections.Generic;

namespace Nik.Api.Models;

public partial class Achievement
{
    public int AchievementId { get; set; }

    public string Title { get; set; } = null!;

    public string Icon { get; set; } = null!;

    public int Number { get; set; }

}
