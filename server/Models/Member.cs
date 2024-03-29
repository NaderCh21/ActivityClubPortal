﻿using System;
using System.Collections.Generic;

namespace ActivityClubPortal.Models
{
    public partial class Member
    {
        public int MemberId { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Gender { get; set; }
        public DateTime? JoiningDate { get; set; }
        public string? MobileNumber { get; set; }
        public string? EmergencyNumber { get; set; }
        public string? Photo { get; set; }
        public string? Profession { get; set; }
        public string? Nationality { get; set; }
    }
}
