using School.Model;

namespace School.Repo.Interface
{
    public interface IUser:IGenericRepo<User>
    {
        User? GetbyUserName(string userName);
    }
}
