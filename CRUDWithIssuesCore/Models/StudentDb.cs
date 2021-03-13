using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDWithIssuesCore.Models
{
    public static class StudentDb
    {
        public static Student Add(Student p, SchoolContext context)
        {
            //Add student to context
            context.Students.Add(p);
            context.SaveChanges();
            return p;
        }

        public static List<Student> GetStudents(SchoolContext context)
        {
            return (from s in context.Students
                    select s).ToList();
        }

        public static Student GetStudentId(SchoolContext context, int id)
        {
            Student p2 = context
                            .Students
                            .Where(stu => stu.StudentId == id)
                            .SingleOrDefault();
            return p2;
        }

        public static void Delete(SchoolContext context, Student stu)
        { 
            //Mark the object as deleted
            context.Remove(stu);

            //Send delete query to database
            context.SaveChanges();
        }

        public static Student Update(SchoolContext context, Student stu)
        {
            context.Entry(stu).State = EntityState.Modified;

            context.SaveChanges();

            return stu;
        }
    }
}
