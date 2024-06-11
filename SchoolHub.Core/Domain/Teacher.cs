#nullable disable
using System;
using System.Collections.Generic;

namespace SchoolHub.Core.Domain;

public partial class Teacher
{
    public int Id { get; set; }

    public string Name { get; set; }

    public int? Age { get; set; }

    public string EmployeeId { get; set; }

    public string Gender { get; set; }

    public string PhoneNumber { get; set; }

    public string Address1 { get; set; }

    public string Address2 { get; set; }

    public string AddressCity { get; set; }

    public string AddressPincode { get; set; }

    public virtual ICollection<Class> ClassClassTeachers { get; set; } = new List<Class>();

    public virtual ICollection<Class> ClassEnglishTeachers { get; set; } = new List<Class>();

    public virtual ICollection<Class> ClassMathsTeachers { get; set; } = new List<Class>();

    public virtual ICollection<Class> ClassScienceTeachers { get; set; } = new List<Class>();
}