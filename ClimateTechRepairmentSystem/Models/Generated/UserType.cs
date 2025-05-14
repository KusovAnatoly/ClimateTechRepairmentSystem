using System;
using System.Collections.Generic;

namespace ClimateTechRepairmentSystem.Models.Generated;

public partial class UserType
{
    public int UserTypeId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
