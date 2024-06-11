#nullable disable
using System;
using System.Collections.Generic;

namespace SchoolHub.Core.Domain;

//Model, DataModel, Domain
public partial class Class
{
    public int Id { get; set; }

    public string ClassName { get; set; }

    public string Section { get; set; }

    public int? EnglishTeacherId { get; set; }

    public int? ScienceTeacherId { get; set; }

    public int? MathsTeacherId { get; set; }

    public int? ClassTeacherId { get; set; }

    public virtual Teacher ClassTeacher { get; set; }

    public virtual Teacher EnglishTeacher { get; set; }

    public virtual Teacher MathsTeacher { get; set; }

    public virtual Teacher ScienceTeacher { get; set; }

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}