using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ASPWebAPI5.Models;

namespace ASPWebAPI5.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        //public IHttpActionResult Get(int x)
        //{
        //    String HelloWorld =  String.Concat("Hello World" , x);
        //    return Ok(HelloWorld);
        //}

        // GET api/values
        public string Get(Student std)
        {
            return $"Hello - {std.id}, {std.name}";
        }

        [HttpGet]
        public List<Student>  GetAllStudents(int id)
        {
             return Student.GetStudents(id);
        }

        [HttpPost]
        public int PostStudent([FromBody]Student stud)
        {
            int recsAdded = stud.id;
            // Posted student to DB
            return recsAdded;
        }
        // GET api/values
        //public Student Post([FromBody] Student stud)
        //{
        //    return Student.GetStudent(stud);
        //}

        // GET api/values/5
        public string GetStudentName(int id, string name)
        {
            return $"value with name -{name}, Id - {id}";
        }

        // POST api/values
        public string Post( string value)
        {
            return $"Vaue passed : {value}";
        }

        // PUT api/values/5
        //public Student Put(int id, [FromBody] String nameofStud)
        //{
        //    Student st = new Student();
        //    st.id = id;
        //    st.name = nameofStud;
        //    return Student.GetStudent(st);
        //}

        [HttpPut]
        public int PutStudent(int id, [FromBody] Student Stud)
        {
            Student st = Stud;
            return id + st.id;
        }

        // DELETE api/values/5
        public int Delete(int id)
        {
            return id + 1;
        }
    }
}
