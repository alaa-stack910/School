using School.Model;
using School.Repo.Interface;

namespace School.Repo.Implement
{
    public class ImUser:ImGenericRepo<User>,IUser
    {
        private readonly AppContexts _context;
        public ImUser(AppContexts context) : base(context)
        {
            _context = context;
        }

     public   User? GetbyUserName(string userName)
        {
     return _context.Users.FirstOrDefault(x => x.UserName == userName);
        }

    }
}
