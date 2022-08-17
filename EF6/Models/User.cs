using System;

namespace EF6.Models
{
    public class User
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
    }
}
