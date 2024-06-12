using SchoolHub.Service.ViewModel;

namespace SchoolHub.Service.Interfaces
{
    public interface IStudentService
    {
        List<StudentViewModel> GetStudentListByClass(string className, string sectionName);
    }
}