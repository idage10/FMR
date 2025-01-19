using FlightAlertData.Alert;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAlertLogic.Alert
{
    public interface IAlertLogic
    {
        public IQueryable<AlertDTO> GetAlerts();
        public Task<AlertDTO> GetAlert(int id);
        public Task<bool> CreateAlert(AlertDTO alert);
        public Task<bool> UpdateAlert(AlertDTO alert);
        public Task<bool> DeleteAlert(int id);
    }
}
