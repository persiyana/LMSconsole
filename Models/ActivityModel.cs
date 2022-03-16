namespace LMSconsole.Models
{
    class ActivityModel
    {
        public int ActivityId { get; set; }
        public int ReaderId { get; set; }
        public int BookId { get; set; }
        public DateTimeOffset GivenAt { get; set; }
        public DateTimeOffset ReturnedAt { get; set; }
    }
}
