using System.ComponentModel.DataAnnotations;

namespace PenBook.Models.Domain
{
    public class Author
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string AuthorName { get; set; }

        public virtual IEnumerable<Book>? Book { get; set; }
    }
}
