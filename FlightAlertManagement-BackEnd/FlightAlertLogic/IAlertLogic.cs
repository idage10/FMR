using FlightAlertData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAlertLogic
{
    public interface IAlertLogic
    {
        public IQueryable<AlertDTO> GetAlerts();
        public Task<AlertDTO> GetAlert(int id);
        public Task CreateAlert(AlertDTO alert);
        public Task<AlertDTO> UpdateAlert();
        public Task<AlertDTO> DeleteAlert(int id);
    }
}
