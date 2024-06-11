using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SchoolHub.API.Model;
using SchoolHub.API.ViewModel;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace SchoolHub.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : Controller
    {
        [HttpGet]
        [Route("LearnLINQ")]
        public bool LearnLINQ()
        {
            List<StudentModel> studentList = new List<StudentModel>();
            studentList.Add(new StudentModel()
            {
                Id = 1,
                StudentName = "Sundar",
                BloodGroup = "O+"
            });
            studentList.Add(new StudentModel()
            {
                Id = 2,
                StudentName = "Kannan",
                BloodGroup = "A+"
            });
            studentList.Add(new StudentModel()
            {
                Id = 3,
                StudentName = "Guru",
                BloodGroup = "O+"
            });
            //Assuming the above code already mapped; 

            //Language Integrated Query (LINQ)
            var studentNameList =
            from student in studentList
            where student.BloodGroup == "O+"
            select student.StudentName;

            //Lamda Expression
            var LStudentNameList = studentList.Where(x => x.BloodGroup == "O+")
                .Select(x => x.StudentName)
                .ToList();


            return true;
        }

        [HttpGet]
        [Route("AddStudent")]
        public bool AddStudent()
        {
            //SchoolHubDBContext schoolHubDBContext = new SchoolHubDBContext();
            //schoolHubDBContext.Siblings.Add(
            //    new Sibling()
            //    {
            //        SiblingName = "Karthick"
            //    }
            //);
            //schoolHubDBContext.SaveChanges();
            return true;
        }

        [HttpGet]
        [Route("GetStudentList")]
        public bool GetStudentList()
        {
        //    SchoolHubDBContext schoolHubDBContext = new SchoolHubDBContext();
        //    var students = schoolHubDBContext.Students
        //                   .Include(student => student.Siblings)
        //                   .Include(student => student.Class)
        //                   .ToList();
           return true;
        }
        [HttpGet]
        [Route("GetStudentsList")]
        public List<StudentViewModel> GetStudentsList()
        {
            SchoolHubDBContext schoolHubDBContext = new SchoolHubDBContext();
            var iqueryableStudentList = schoolHubDBContext.Students.Select(x => new StudentViewModel()
            {
                Name = x.Name,
                Age = x.Age,
                Gender = x.Gender,
                BloodGroup = x.BloodGroup
            });
            var studentList = iqueryableStudentList.ToList();
            return studentList;

        }


        [HttpGet]
        [Route("GetTeachersList")]
        public List<TeacherViewModel> GetTeachersList()
        {
            //SchoolHubDBContext schoolHubDBContext = new SchoolHubDBContext();
            //var iqueryableTeacherList = schoolHubDBContext.Teachers.Select(x => new TeacherViewModel()
            //{
            //    EmployeeId = x.EmployeeId,
            //    Name = x.Name,
            //    Age = x.Age,
            //    Gender = x.Gender
            //}).Where(x=> x.Gender == "Female");

            //var teacherList = iqueryableTeacherList.ToList();
            return new List<TeacherViewModel>();
        }
       
        [HttpGet]
        [Route("GetStudentListByClass/{className}")]
        public List<StudentModel> GetStudentListByClass(string className)
        {
            var studentList = new List<StudentModel>();

            var connectionString = "Server=tcp:schoolhub.database.windows.net,1433;Initial Catalog=school_hub;Persist Security Info=False;User ID=schooladmin;Password=Password123#;TrustServerCertificate=False;";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            var sqlQuery = @"SELECT rollnumber,NAME,gender,
                                    bloodgroup,fathername,contactnumber1,
                                    class.class
                            FROM    student
                                    JOIN class
                                      ON student.classid = class.id
                            WHERE   class.class = '" + className + "'";
            SqlCommand cmd = new SqlCommand(sqlQuery, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var student = new StudentModel()
                {
                    RollNumber = reader.GetString(0),
                    StudentName = reader.GetString(1),
                    Gender = reader.GetString(2),
                    BloodGroup = reader.GetString(3),
                    FatherName = reader.GetString(4),
                    ContactNumber = reader.GetString(5)
                };
                studentList.Add(student);
            }
            connection.Close();
            return studentList;
        }

        [HttpPost]
        [Route("UpdateStudent")]
        public bool UpdateStudent(StudentModel studentModel)
        {
            var connectionString = "Server=tcp:schoolhub.database.windows.net,1433;Initial Catalog=school_hub;Persist Security Info=False;User ID=schooladmin;Password=Password123#;TrustServerCertificate=False;";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            var sqlQuery = @"update student set name = @studentName where id = @studentId";
            SqlCommand cmd = new SqlCommand(sqlQuery, connection);
            cmd.Parameters.Add("@studentName",SqlDbType.VarChar);
            cmd.Parameters.Add("@studentId", SqlDbType.Int);
            cmd.Parameters["@studentName"].Value = studentModel.StudentName;
            cmd.Parameters["@studentId"].Value = studentModel.Id;
            int rowsAffected =  cmd.ExecuteNonQuery();
            return rowsAffected > 0;
        }
    }
}
