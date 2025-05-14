using System;
using System.Collections.Generic;

namespace ClimateTechRepairmentSystem.Models.Generated;

public partial class RepairPart
{
    public int RepairPartId { get; set; }

    public int RequestId { get; set; }

    public string RepairPart1 { get; set; } = null!;

    public virtual Request Request { get; set; } = null!;
}
