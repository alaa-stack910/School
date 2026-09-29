using School.Repo.Interface;
using School.Model;
namespace School.Repo.Implement
{
    public class ImStudent: ImGenericRepo<Student>, Istudent
    {
        private readonly AppContexts _context;
        public ImStudent(AppContexts context):base(context)
        {
            _context = context;
        }
        public ICollection<Student> Filter(int id)
        {
            var students = _context.Students.Where(s => s.ClassRoomId == id).ToList();
            return students;
        }
    }
}
