using System;
using System.Collections.Generic;

namespace ActivityClubPortal.Models
{
    public partial class Lookup
    {
        public int LookupId { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public int? Order { get; set; }
    }
}
