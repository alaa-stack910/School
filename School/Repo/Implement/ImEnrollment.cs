using Microsoft.EntityFrameworkCore;
using School.Model;
using School.Repo.Interface;
namespace School.Repo.Implement
{
    public class ImEnrollment: ImGenericRepo<Enrollment>, IEnrollment
    {
        private readonly AppContexts _context;
        public ImEnrollment(AppContexts context) : base(context)
        {
            _context = context;
        }

        public Enrollment GetOldestEnrollment(int id)
        {
            var v = _context.Enrollments.Include(i => i.Subject).Where(o => o.SubjectId == id).OrderBy(p => p.EnrollmentDate).LastOrDefault();
            return v;
        }

    }
}
