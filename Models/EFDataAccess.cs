using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure;

namespace ASPWebAPI5.Models
{
    // This is a Data Transfer Object (DTO)
    [NotMapped]
   public class StdIdAndName
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
    }
    public class EFDataAccess
    {
        List<Student> stdList = new List<Student>();
        List<Grade> grdList = new List<Grade>();

        // Return all student as a Generic Collection
        public List<Student> GetAllStudents()
        {
            try
            {
                using (
                    var ctx = new SchoolDBContext())
                {   // Get all the student records 
                    stdList = ctx.Students.ToList();
                    //stdList = ctx.Students.OrderBy(s => s.StudentName).ToList();

                    // Explicit loading of the Grade
                    foreach (Student st in stdList)
                    {
                        ctx.Entry(st).Reference(s => s.grade).Load();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return stdList;
        }


        // Return one Student given the Student Id
        public Student GetStudentById(int stdId)
        {
            Student std = new Student();
            try 
            { 
                // Get students with a Where clause
                using (var ctx = new SchoolDBContext())
                {
                    std = ctx.Students.Where(s => s.StudentId == stdId).Single();
                    ctx.Entry(std).Reference(s => s.grade).Load();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return std;
        }

        // Return one Student given the Student Id
        public Student GetStudentByName(int stdId, string stdName)
        {
            Student std = new Student();
            try
            {
                // Get students with a Where clause
                using (var ctx = new SchoolDBContext())
                {
                    std = ctx.Students.Where(s => s.StudentId == stdId && s.StudentName == stdName).Single();
                    ctx.Entry(std).Reference(s => s.grade).Load();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return std;
        }

        // Return all students as a Generic Collection, based on the GradeId
        public List<Student> GetAllStudentsByGrade(int grdId)
        {
            try
            {
                // Get students Orderby Grade or by grade
                using (var ctx = new SchoolDBContext())
                {   // Get all the student and grade records 
                    stdList = ctx.Students.Where(s => s.GradeId == grdId).ToList();
                    //stdList = ctx.Students.Where(s => s.GradeId == grdId).OrderBy(s => s.StudentName).ToList();
                    //stdList = ctx.Students.OrderBy(s => s.GradeId).ThenBy(s => s.StudentName).ToList();
                }
            }
            catch (Exception ex)
            { throw ex;
            }
            return stdList;
        }

        // Get data into a DTO, only Std Id and Name
        public List<StdIdAndName> GetStudentIdAndName()
        {
            List<StdIdAndName> sList = new List<StdIdAndName>();
            try
            {
                using (var ctx = new SchoolDBContext())
                {
                    sList = ctx.Students.Select(s => new StdIdAndName
                    {
                        StudentId = s.StudentId,
                        StudentName = s.StudentName
                    }).ToList();
                }
            }
            catch (Exception ex)
            {   // You can make an entry in a log file here.
                throw ex;
            }
            return sList;
        }

        // Update Student, given the Student object
        public int UpdateStudent(Student s1)
        {
            int retValue = 0;
            if (s1.StudentId > 0)
            {
                try
                {
                    using (var ctx = new SchoolDBContext())
                    {
                        ctx.Students.Attach(s1);
                        ctx.Entry(s1).State = System.Data.Entity.EntityState.Modified;
                        retValue = ctx.SaveChanges();
                    }
                }
                catch (DbUpdateConcurrencyException ex)
                {   // You can make an entry in a log file here.
                    throw ex;
                }
                catch (Exception ex)
                {   // You can make an entry in a log file here.
                    throw ex;
                }
            }
            return retValue;
        }

        // Update Student, given the Student object
        public int UpdateStudentById(int stdId, Student s1)
        {
            int retValue = 0;
            Student std = new Student();

            if (stdId  > 0)
            {
                try
                {
                    using (var ctx = new SchoolDBContext())
                    {
                        std = ctx.Students.Find(stdId);
                        // Match is found
                        if (std != null)
                        {
                            ctx.Students.Attach(s1);
                            ctx.Entry(s1).State = System.Data.Entity.EntityState.Modified;
                            retValue = ctx.SaveChanges();
                        }
                    }
                }
                catch (DbUpdateConcurrencyException ex)
                {   // You can make an entry in a log file here.
                    throw ex;
                }
                catch (Exception ex)
                {   // You can make an entry in a log file here.
                    throw ex;
                }
            }
            return retValue;
        }

        // Add a student record
        public int AddStudent(Student s1)
        {
            int retValue = 0;
            if (s1 != null)
            {
                try
                {
                    using (var ctx = new SchoolDBContext())
                    {
                        ctx.Students.Add(s1);
                        retValue = ctx.SaveChanges();
                    }
                }
                catch (Exception ex)
                {   // You can make an entry in a log file here.
                    throw ex;
                }
            }
            return retValue;
        }

        // Delete a student record, give the StudentId
        public int DeleteStudent(int stdId)
        {
            int retValue = 0;
                try
                {
                    using (var ctx = new SchoolDBContext())
                    {
                        //Student std = ctx.Students.Where(s => s.StudentId == stdId).Single();
                        Student s1 = ctx.Students.Find(stdId);
                        if (s1 != null)
                        {
                            ctx.Entry(s1).State = System.Data.Entity.EntityState.Deleted;
                            retValue = ctx.SaveChanges();
                        }
                    }

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            return retValue;
        }
    }
}
