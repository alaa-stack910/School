using School.Model;

namespace School.Repo.Interface
{
    public interface ITeacher:IGenericRepo<Teacher>
    {
      public  ICollection<Teacher> FilterOnSalary(int salary, int id);
        public Teacher GetEmail(string email);
        public bool CheckSubjectTaught(int id);

    }
}
