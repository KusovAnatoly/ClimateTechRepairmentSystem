using System;
using System.Collections.Generic;

namespace ClimateTechRepairmentSystem.Models.Generated;

public partial class Comment
{
    public int CommentId { get; set; }

    public string Message { get; set; } = null!;

    public int MasterId { get; set; }

    public int RequestId { get; set; }

    public virtual Master Master { get; set; } = null!;

    public virtual Request Request { get; set; } = null!;
}
