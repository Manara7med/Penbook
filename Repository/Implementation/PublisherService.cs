using Microsoft.EntityFrameworkCore;
using PenBook.Models.Domain;
using PenBook.Repository.Abstract;

namespace PenBook.Repository.Implementation
{
    public class PublisherService : IPublisherService
    {
        private readonly DatabaseContext context;
        public PublisherService(DatabaseContext context)
        {
            this.context = context;
        }
        public bool Add(Publisher model)
        {
            try
            {
                context.publisher.Add(model);
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
                context.publisher.Remove(data);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Publisher FindById(int id)
        {
            return context.publisher
                  .Include(b => b.Book).ThenInclude(b => b.Genre)
                  .Include(b => b.Book).ThenInclude(c => c.Author)
                  .FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Publisher> GetAll()
        {
            return context.publisher.ToList();
        }

        public bool Update(Publisher model)
        {
            try
            {
                context.publisher.Update(model);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public Publisher Find(int id)
        {
            return context.publisher
                .Include(b => b.Book).ThenInclude(b => b.Genre)
                .Include(b => b.Book).ThenInclude(c => c.Author)
                .FirstOrDefault(p => p.Id == id);
        }
    }
}
