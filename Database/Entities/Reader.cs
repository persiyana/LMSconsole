namespace LMSconsole.Database.Entities
{
    public class Reader
    {
        [Key] public int ReaderId { get; set; }
        [Required] public string Name { get; set; }
        public string Address { get; set; }
        [Required] public string PhoneNumber { get; set; }
        public string Email { get; set; }
        [Required] public bool IsStudent { get; set; }

        public virtual ICollection<Activity> Activities { get; set; }
    }
}
