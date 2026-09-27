using School.Model;

namespace School.Repo.Interface
{
    public interface IStudent
    {
          public  List<Student> GetAll();

        //List<Student> GetByClassRoomId(int classRoomId);

        public Student GetById(int id);

        //ClassRoom GetClassRoomByName(string name);

        public Student Add(Student student);

        public Student Update(Student student);

        public Student Delete(Student student);
        
    }
}
