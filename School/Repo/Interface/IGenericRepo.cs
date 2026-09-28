using School.Model;

namespace School.Repo.Interface
{
    public interface IGenericRepo<T> where T : class
    {
          public  ICollection<T> GetAll();

        //List<Student> GetByClassRoomId(int classRoomId);

        public T GetById(int id);

        //ClassRoom GetClassRoomByName(string name);

        public void Add(T entity);

        public void Update(T entity);

        public void Delete(T entity);
    }
}
