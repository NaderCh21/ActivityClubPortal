using System;
using System.Collections.Generic;

namespace ActivityClubPortal.Models
{
    public partial class Event
    {
        public int EventId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? CategoryId { get; set; }
        public string? Destination { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public decimal? Cost { get; set; }
        public string? Status { get; set; }
        public int? GuideId { get; set; }

        public virtual User? Guide { get; set; }
    }
}
