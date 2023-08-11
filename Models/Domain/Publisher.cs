using System.ComponentModel.DataAnnotations;

namespace PenBook.Models.Domain
{
    public class Publisher
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string PublisherName { get; set; }
        public virtual IEnumerable<Book>? Book { get; set; }
    }
}
