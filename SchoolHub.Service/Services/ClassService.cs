using SchoolHub.Infrastructure;
using SchoolHub.Service.ViewModel.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolHub.Service.Services
{
    public class ClassService
    {
        public List<ClassViewModel> GetClasses()
        {
            var schoolHubDBContext = new SchoolHubDBContext();
            var classList = schoolHubDBContext.Classes.Select(x => new ClassViewModel()
            {
                ClassName = x.ClassName,
                Section = x.Section,
                ClassTeacherName = x.ClassTeacher.Name,
                EnglishTeacherName = x.EnglishTeacher.Name,
                MathsTeacherName = x.MathsTeacher.Name,
                ScienceTeacherName = x.ScienceTeacher.Name
            }).ToList();
            return classList;
        }
    }
}
