using SchoolHub.Service.ViewModel.Student;

namespace SchoolHub.Service.Interfaces
{
    public interface IStudentService
    {
        List<StudentViewModel> GetStudentListByClass(string className, string sectionName);
        bool AddStudent(AddStudentViewModel addStudentViewModel);
        List<string> GetClassList();

        List<string> GetSectionListByClass(string className);
    }
} 