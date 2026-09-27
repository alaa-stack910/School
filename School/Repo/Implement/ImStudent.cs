using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using School.Model;
using School.Repo.Interface;

namespace School.Repo.Implement
{
    public class ImStudent:IStudent
    {
        private readonly AppContexts appContexts;

        public ImStudent(AppContexts appContexts)
        {
            this.appContexts = appContexts;
        }

        public List<Student> GetAll()
        {
             var v = appContexts.Students
                .Include(s => s.ClassRoom)
                .ToList();
            return v;
        }

        //public List<Student> GetByClassRoomId(int classRoomId)
        //{
        //     var s= appContexts.Students
        //        .Where(s => s.ClassRoomId == classRoomId)
        //        .OrderBy(s => s.Id)
        //        .Include(s => s.ClassRoom)
        //        .ToList();
        //    return s;
        //}

        public Student GetById(int id)
        {
            var s = appContexts.Students
                .Include(s => s.ClassRoom)
                .FirstOrDefault(s => s.Id == id);
            return s;
        }

        //public ClassRoom? GetClassRoomByName(string name)
        //{
        //    return appContexts.ClassRooms
        //        .FirstOrDefault(c => c.Name == name);

        //}

        public Student Add(Student student)
        {
            appContexts.Students.Add(student);
            appContexts.SaveChanges();

            return student;
        }

        public Student Update(Student student)
        {
            appContexts.Students.Update(student);
            appContexts.SaveChanges();

            return student;
        }

        public Student Delete(Student student)
        {
            var s = appContexts.Students
                .FirstOrDefault(s => s.Id == student.Id);

            if (s == null)
            {
                return null;
            }

            appContexts.Students.Remove(s);
            appContexts.SaveChanges();

            return s;
        }


    }
}
