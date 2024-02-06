using System;
using System.Collections.Generic;

namespace ActivityClubPortal.Models
{
   public partial class Guide
{
    public int GuideId { get; set; }
    public string? FullName { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public DateTime? DateOfBirth { get; set; }  // Use DateTime? instead of DateOnly?
    public DateTime? JoiningDate { get; set; }  // Use DateTime? instead of DateOnly?
    public string? Photo { get; set; }
    public string? Profession { get; set; }
}

}
