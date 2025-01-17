using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAlertData
{
    public interface IAlertData
    {
        public Task<IQueryable<AlertDTO>> GetAlerts();
        public Task<AlertDTO> GetAlert(int id);
        public Task<AlertDTO> CreateAlert(AlertDTO alert);
        public Task<AlertDTO> UpdateAlert();
        public Task<AlertDTO> DeleteAlert(int id);
    }
}
