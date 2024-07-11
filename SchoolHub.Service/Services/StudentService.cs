using Microsoft.EntityFrameworkCore;
using SchoolHub.Core.Domain;
using SchoolHub.Infrastructure;
using SchoolHub.Service.Interfaces;
using SchoolHub.Service.ViewModel.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolHub.Service.Services
{
    public class StudentService : IStudentService
    {
        public List<StudentViewModel> GetStudentListByClass(string className, string sectionName)
        {
            SchoolHubDBContext schoolHubDBContext = new SchoolHubDBContext();
            var studentList = schoolHubDBContext.Students.Include(x => x.Class)
                                               .Where(x => x.Class.ClassName == className
                                                      && x.Class.Section == sectionName);

            var studentViewList = studentList.Select(x => new StudentViewModel()
            {
                Name = x.Name,
                Age = DateTime.Today.Year - x.DateOfBirth.Year,
                BloodGroup = x.BloodGroup,
                Gender = x.Gender,
                PhotoFilePath = x.PhotoFilePath,
            }).ToList();

            return studentViewList;
        }

        public bool AddStudent(AddStudentViewModel addStudentViewModel)
        {
            var schoolHubDBContext = new SchoolHubDBContext();
            var classobj=schoolHubDBContext.Classes.FirstOrDefault(x => x.ClassName == "5" && x.Section == "A");
            schoolHubDBContext.Students.Add(new Student
            {
                Name = addStudentViewModel.StudentName,
                DateOfBirth = addStudentViewModel.DateOfBirth,
                Gender = addStudentViewModel.Gender,
                FatherName = addStudentViewModel.FatherName,
                MotherName = addStudentViewModel.MotherName,
                ContactNumber1 = addStudentViewModel.ContactNumber1,
                ContactNumber2 = addStudentViewModel.ContactNumber2,
                BloodGroup = addStudentViewModel.BloodGroup,
                Class = classobj
            });
            var result = schoolHubDBContext.SaveChanges();
            return (result > 0);
        }
    }
}