
using System.Security.Policy;
using School.Model;
using School.Repo.Interface;
namespace School.Repo.Implement
{
    public class ImTeacher : ImGenericRepo<Teacher>, ITeacher
    {
        private readonly AppContexts _context;
        public ImTeacher(AppContexts context) : base(context)
        {
            _context = context;
        }
      public  ICollection<Teacher> FilterOnSalary(int salary, int id)
        {
            var t= _context.Teachers.Where(s => s.Salary > salary&& s.TeacherId==id).ToList();
            return t;
        }
        public Teacher GetEmail(string email)
        {
            var t = _context.Teachers.FirstOrDefault(s => s.Email == email);
            return t;
        }

        public bool CheckSubjectTaught(int id)
        {
            var t = _context.Teachers.Any(s => s.TeacherId == id);
            return t;
        }
    }
}
