using System;

namespace FlightAlertData
{
    public class AlertDTO
    {
        public int AlertId { get; set; }
        public int UserId { get; set; }
        public string FlightSource { get; set; }
        public string FlightDestination { get; set; }
        public decimal PriceThreshold { get; set; }
        public bool IsActive { get; set; }
    }
}
