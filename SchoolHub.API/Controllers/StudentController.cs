using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using SchoolHub.API.Model;
using System.Collections.Generic;

namespace SchoolHub.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : Controller
    {
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
            return studentList;
        }
    }
}
