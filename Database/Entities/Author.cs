using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkPlayground.Database.Entities
{
    public class Author
    {
        [Key] public int AuthorId { get; set; }

        [Required] public string Name { get; set; }

        public DateTimeOffset DateOfBirth { get; set; }

        public string Nationality { get; set; }
        public bool IsAlive { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
