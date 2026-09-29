

using School.Model;

namespace School.Repo.Interface
{
    public interface Istudent : IGenericRepo<Student>
    {
        ICollection<Student> Filter(int id);
    }
}
