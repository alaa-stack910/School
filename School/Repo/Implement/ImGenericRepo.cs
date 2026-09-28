using System.Runtime.Intrinsics.Arm;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using School.Model;
using School.Repo.Interface;

namespace School.Repo.Implement
{
    public class ImGenericRepo<T> : IGenericRepo<T> where T : class
    {
        private readonly AppContexts appContexts;
        public DbSet<T> db;

        public ImGenericRepo(AppContexts appContexts)
        {
            this.appContexts = appContexts;
            db = appContexts.Set<T>();
        }


        public ICollection<T> GetAll()
        {
            return db.ToList();
        }

        //List<Student> GetByClassRoomId(int classRoomId);

        public T GetById(int id)
        {
             var  v = db.Find(id);
            return v;
        }

        //ClassRoom GetClassRoomByName(string name);

        public void Add(T entity)
        {
            db.Add(entity);
            appContexts.SaveChanges();
        }

        public void Update(T entity)
        {
            db.Update(entity);
            appContexts.SaveChanges();

        }

        public void Delete(T entity)
        {
            db.Remove(entity);
            appContexts.SaveChanges();

        }
    }
}
