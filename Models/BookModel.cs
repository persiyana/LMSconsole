namespace LMSconsole.Models
{
    class BookModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int AuthorId { get; set; }

        public DateTimeOffset IssuedAt { get; set; }

        public bool IsAvailable { get; set; }
    }
}
