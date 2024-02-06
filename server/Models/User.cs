using System;
using System.Collections.Generic;

namespace ActivityClubPortal.Models
{
    public partial class User
    {
        public User()
        {
            Events = new HashSet<Event>();
        }

        public int UserId { get; set; }
        public string? Name { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Gender { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Role { get; set; }

        public virtual ICollection<Event> Events { get; set; }
    }
}
