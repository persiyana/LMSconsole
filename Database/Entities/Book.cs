using System.ComponentModel.DataAnnotations;

namespace LMSconsole.Database.Entities
{
    public class Book
    {
        [Key] public int BookId { get; set; }

        [Required] public string Title { get; set; }

        public int AuthorId { get; set; }

        public DateTimeOffset IssuedAt { get; set; }

        public bool IsAvailable { get; set; }
        public virtual Author Author { get; set; }
        public virtual ICollection<Activity> Activities { get; set; }
    }
}