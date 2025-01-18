using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FlightAlertData.Models
{
    public partial class Alerts
    {
        public int AlertId { get; set; }
        public int UserId { get; set; }
        public string FlightSource { get; set; }
        public string FlightDestination { get; set; }
        public decimal PriceThreshold { get; set; }
        public bool IsActive { get; set; }
    }
}
