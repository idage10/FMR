using System;
using System.Collections.Generic;
using System.Text;

namespace FlightAlertData.Models
{
    public partial class Users
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
