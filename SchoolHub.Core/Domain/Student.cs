#nullable disable
using System;
using System.Collections.Generic;

namespace SchoolHub.Core.Domain;

public partial class Student
{
    public int Id { get; set; }

    public string Name { get; set; }

    public DateTime DateOfBirth { get; set; }

    public string RollNumber { get; set; }

    public string Gender { get; set; }

    public int? ClassId { get; set; }

    public string BloodGroup { get; set; }

    public string FatherName { get; set; }

    public string MotherName { get; set; }

    public string ContactNumber1 { get; set; }

    public string ContactNumber2 { get; set; }

    public string ContactEmailId { get; set; }

    public string PhotoFilePath { get; set; }

    public string Address1 { get; set; }

    public string Address2 { get; set; }

    public string AddressCity { get; set; }

    public string AddressPincode { get; set; }

    public virtual Class Class { get; set; }

    public virtual ICollection<Sibling> Siblings { get; set; } = new List<Sibling>();
}