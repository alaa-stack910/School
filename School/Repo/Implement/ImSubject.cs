using School.Model;
using School.Repo.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace School.Repo.Implement
{
    public class ImSubject: ImGenericRepo<Subject>, ISubject
    {
        private readonly AppContexts _context;
        public ImSubject(AppContexts context) : base(context)
        {
            _context = context;
        }
        public string TaughtByTeacher(int id)
        {
            var v = _context.Subjects.Include(i=>i.Teacher).Where(c => c.TeacherId == id).OrderBy(v => v.Name).Select(a => new
            {
                a.Name
            }).FirstOrDefault();
            return v.Name;
        }
        public Subject TaughtByTeacherLast(int id)
        {
            var v = _context.Subjects.Include(i => i.Teacher).Where(c => c.TeacherId == id && c.Id== _context.Subjects.Max(i=>i.Id)).FirstOrDefault();
            return v;
        }

    }
}
