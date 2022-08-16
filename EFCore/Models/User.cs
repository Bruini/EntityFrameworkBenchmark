namespace EFCore.Models
{
    public class User
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
    }
}
