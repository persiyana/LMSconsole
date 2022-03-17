namespace LMSconsole.Database.Entities
{
    public class Activity
    {
        [Key] public int ActivityId { get; set; }

        [Required] public int BookId { get; set; }

        [Required] public int ReaderId { get; set; }

        public DateTimeOffset GivenAt { get; set; }

        public DateTimeOffset ReturnedAt { get; set; }

        public virtual Book Book { get; set; }
        public virtual Reader Reader { get; set; }
        public virtual Book Book { get; set; }

    }
}
