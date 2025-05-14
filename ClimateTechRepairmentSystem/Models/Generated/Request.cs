using System;
using System.Collections.Generic;

namespace ClimateTechRepairmentSystem.Models.Generated;

public partial class Request
{
    public int RequestId { get; set; }

    public DateOnly DateStarted { get; set; }

    public int TechTypeId { get; set; }

    public string Model { get; set; } = null!;

    public string ProblemDescription { get; set; } = null!;

    public int RequestStatusId { get; set; }

    public DateOnly? DueDate { get; set; }

    public int? MasterId { get; set; }

    public int ClientId { get; set; }

    public virtual Client Client { get; set; } = null!;

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual Master? Master { get; set; }

    public virtual ICollection<RepairPart> RepairParts { get; set; } = new List<RepairPart>();

    public virtual RequestStatus RequestStatus { get; set; } = null!;

    public virtual TechType TechType { get; set; } = null!;
}
