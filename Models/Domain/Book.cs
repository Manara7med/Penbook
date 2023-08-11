using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PenBook.Models.Domain
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Title { get; set; }
        [Required]
        public string? Isbn { get; set; }
        [Required]
        public int TotalPages { get; set; }
        [Required]
        public int AuthorId { get; set; }
        [ForeignKey("AuthorId")]
        public virtual Author? Author {get; set;}
        [Required]
        public int PublisherId { get; set; }
        [ForeignKey("PublisherId")]
        public virtual Publisher? Publisher { get; set; }
        [Required]
        public int GenreId { get; set; }
        [ForeignKey("GenreId")]
        public virtual Genre? Genre { get; set; }

        [NotMapped]
        public List<SelectListItem>? AuthorList { get; set; }

        [NotMapped]
        public List<SelectListItem>? PublisherList { get; set; }
        [NotMapped]
        public List<SelectListItem>? GenreList { get; set; }
    }
}
