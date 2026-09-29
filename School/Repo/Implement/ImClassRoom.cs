using System.Diagnostics;
using System.Security.Policy;
using School.Model;
using School.Repo.Interface;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace School.Repo.Implement
{
    public class ImClassRoom: ImGenericRepo<ClassRoom>, IClassRoom
    {
        private readonly AppContexts _context;
        public ImClassRoom(AppContexts context) : base(context)
        {
            _context = context;
        }
        public ClassRoom GetByCapacity(int capacity)
        {
            var c = _context.ClassRooms.FirstOrDefault(s => s.Capacity >= capacity);
            return c;
        }
        public ClassRoom GetByName(string name)
        {
            var c = _context.ClassRooms.FirstOrDefault(s => s.Name == name);
            return c;

        }

        public ClassRoom GetByIndex(int index)
        {
            var c = _context.ClassRooms.OrderBy(j=>j.Id).ElementAt(index);
            return c;
        }

        public bool GetByGrade(int grade, int capacity)
        {
            var c = _context.ClassRooms.All(i => i.GradeLevel == grade && _context.ClassRooms.Any(h => h.Capacity == capacity));
            return c;
        }
    }
}
