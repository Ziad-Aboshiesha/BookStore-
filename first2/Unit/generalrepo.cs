using first2.Models;
namespace first2.Unit
{
    public class generalrepo <TEntity> where TEntity : class
    {
        public BookStoreContext db;
        public generalrepo(BookStoreContext db)
        {
            this.db = db;
        }
        public List<TEntity> getall()
        {
            return db.Set<TEntity>().ToList();
        }
        public TEntity getbyid(int id) 
        {
           return db.Set<TEntity>().Find(id);        
        }
        public void delete(int id)
        {
            var item = db.Set<TEntity>().Find(id);
            db.Set<TEntity>().Remove(item);
        }
        public void add(TEntity item)
        {
            db.Set<TEntity>().Add(item);
        }
        public void update(TEntity item) 
        {
            db.Entry(item).State= Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
        public void save()
        {
            db.SaveChanges();
        }

    }
}
