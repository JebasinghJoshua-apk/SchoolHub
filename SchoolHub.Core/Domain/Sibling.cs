#nullable disable
using System;
using System.Collections.Generic;

namespace SchoolHub.Core.Domain;

public partial class Sibling
{
    public int Id { get; set; }

    public string SiblingName { get; set; }

    public int? StudentId { get; set; }

    public virtual Student Student { get; set; }
}