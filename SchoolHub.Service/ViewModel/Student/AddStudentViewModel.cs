using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolHub.Service.ViewModel.Student
{
    public class AddStudentViewModel
    {
        public string StudentName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string PhotoFilePath { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string ContactNumber1 { get; set; }
        public string ContactNumber2 { get; set; }
        public string BloodGroup { get; set; }
        public string ClassStandard { get; set; }
        public string ClassSection { get; set; }
    }
}
