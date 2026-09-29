using School.Model;

namespace School.Repo.Interface
{
    public interface IEnrollment: IGenericRepo<Enrollment>
    {
        public Enrollment GetOldestEnrollment(int id);
    }
}
