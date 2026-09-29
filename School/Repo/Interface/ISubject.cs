using School.Model;

namespace School.Repo.Interface
{
    public interface ISubject: IGenericRepo<Subject>
    {
        public string TaughtByTeacher(int id);
        public Subject TaughtByTeacherLast (int id);

    }
}
