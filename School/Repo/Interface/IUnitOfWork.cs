
using School.Model;
using School.Repo.Implement;
namespace School.Repo.Interface
{
    public interface IUnitOfWork
    {
        public Istudent students { get; }
        public ISubject subject { get; }
        public IEnrollment enrollment { get; }
        public ITeacher teacher { get; }
        public IClassRoom classRoom { get; }
        public IGenericRepo<Department> department { get; }
        public IUser user { get; }
        public void Save();


    }
}
