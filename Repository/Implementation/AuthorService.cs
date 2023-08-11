using Microsoft.EntityFrameworkCore;
using PenBook.Models.Domain;
using PenBook.Repository.Abstract;

namespace PenBook.Repository.Implementation
{
    public class AuthorService: IAuthorService
    {
        private readonly DatabaseContext context;
        public AuthorService(DatabaseContext context)
        {
            this.context = context;
        }
        public bool Add(Author model)
        {
            try 
            { 
                context.Author.Add(model);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Delete(int id)
        {
            try
            {
                var data = this.FindById(id);
                if (data == null)
                    return false;
                context.Author.Remove(data);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public Author FindById(int id)
        {
            return context.Author
                .Include(a => a.Book).ThenInclude(b => b.Genre)
                .Include(c => c.Book).ThenInclude(d => d.Publisher).FirstOrDefault(f=>f.Id==id);
        }
        public IEnumerable<Author>GetAll()
        {
            return context.Author.ToList();
        }
        public bool Update(Author model)
        {
            try
            {
                context.Author.Update(model);
                context.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
        public Author Find(int id)
        {
            return context.Author
                .Include(b => b.Book).ThenInclude(b => b.Publisher)
                .Include(b => b.Book).ThenInclude(b => b.Genre)
                .FirstOrDefault(p => p.Id == id);
        }

    }
}
