using School.Model;
using School.Repo.Interface;

namespace School.Repo.Implement
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly AppContexts _context;
        public Istudent students { get; }
        public ISubject subject { get; }
        public IEnrollment enrollment { get; }
        public ITeacher teacher { get; }
        public IClassRoom classRoom { get; }
        public IGenericRepo<Department> department { get; }
        public IUser user { get; }

        public UnitOfWork(AppContexts _context, Istudent students, ISubject subject, IEnrollment enrollment, ITeacher teacher, IClassRoom classRoom, IGenericRepo<Department> department, IUser users
)
        {
            this.enrollment = enrollment;
            this.students = students;
            this.subject = subject;
            this.teacher = teacher;
            this.classRoom = classRoom;
            this.department = department;
            user = users;

        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
