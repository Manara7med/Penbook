using Microsoft.EntityFrameworkCore;
using PenBook.Models.Domain;
using PenBook.Repository.Abstract;

namespace PenBook.Repository.Implementation
{
    public class GenreService: IGenreService
    {
        private readonly DatabaseContext context;
        public GenreService(DatabaseContext context)
        {
            this.context = context;
        }

        public bool Add(Genre model)
        {
            try
            {
                context.Genre.Add(model);
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
                context.Genre.Remove(data);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Genre FindById(int id)
        {
            return context.Genre
       .Include(a => a.Book).ThenInclude(b => b.Author)
       .Include(c => c.Book).ThenInclude(d => d.Publisher).FirstOrDefault(f => f.Id == id); ;
        }

        public IEnumerable<Genre> GetAll()
        {
            return context.Genre.ToList();
        }

        public bool Update(Genre model)
        {
            try
            {
                context.Genre.Update(model);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public Genre Find(int id)
        {
            return context.Genre
                .Include(b => b.Book).ThenInclude(b => b.Publisher)
                .Include(b => b.Book).ThenInclude(c => c.Author)
                .FirstOrDefault(p => p.Id == id);
        }
    }
}
