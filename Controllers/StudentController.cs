using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using ASPWebAPI5.Models;
using ActionNameAttribute = System.Web.Http.ActionNameAttribute;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
using HttpPutAttribute = System.Web.Http.HttpPutAttribute;

namespace ASPWebAPI5.Controllers
{
    public class StudentController : Controller
    {
        EFDataAccess efDA = new EFDataAccess();
        List<Student> stdList = new List<Student>();
        List<Grade> grdList = new List<Grade>();

        [HttpGet]
        public List<Student> GetAllStudents()
        {
            try
            {
                stdList = efDA.GetAllStudents();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return stdList;
            //return Request.CreateResponse(HttpStatusCode.Found, stdList);
        }

        // GET a Single Student record given the Student Id
        public Student GetStudent(int stdId)
        {
           Student s1 = new Student();
            try
            {
                s1 = efDA.GetStudentById(stdId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return s1;
        }

        [HttpGet, ActionName("GetStudentByName")]
        public Student GetStudentByName(int id, string name)
        {
            Student s1 = new Student();
            try
            {
                s1 = efDA.GetStudentByName(id, name);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return s1;
        }

        // Update Student
        [HttpPost]
        public int PostStudent([FromBody] Student stud)
        {
            int iResult = 0;
            try
            {
                iResult = efDA.AddStudent(stud);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return iResult;
        }

        // Update Student
        [HttpPut]
        public int PutStudent([FromBody] Student stud)
        {
            int iResult = 0;
            try
            {
                iResult = efDA.UpdateStudent(stud);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return iResult;
        }

        // Update Student given Id and Student object
        [HttpPut]
        public int PutStudent(int id, [FromBody] Student Stud)
        {
            int iResult = 0;
            try
            {
                iResult = efDA.UpdateStudentById(id, Stud);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return iResult;
        }

        // DELETE 
        public int DeleteStudent(int id)
        {
            int iResult = 0;
            try
            {
                iResult = efDA.DeleteStudent(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return iResult;
        }
    }
}