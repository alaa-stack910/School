using School.Model;
using School.Repo.Interface;

namespace School.Repo.Implement
{
    public interface IClassRoom: IGenericRepo<ClassRoom>
    {
        public ClassRoom GetByCapacity(int capacity);
        public ClassRoom GetByName(string name);
        public ClassRoom GetByIndex(int index);
        public bool GetByGrade(int grade, int capacity);


    }
}
