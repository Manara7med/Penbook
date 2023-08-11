using System.ComponentModel.DataAnnotations;

namespace PenBook.Models.Domain
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual IEnumerable<Book>? Book { get; set; }
    }
}
