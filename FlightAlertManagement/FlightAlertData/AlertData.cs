using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAlertData
{
    public class AlertData : IAlertData
    {
        public AlertData()
        {
            
        }

        public Task<IQueryable<AlertDTO>> GetAlerts()
        {
            throw new NotImplementedException();
        }

        public Task<AlertDTO> GetAlert(int id)
        {
            throw new NotImplementedException();
        }

        public Task<AlertDTO> CreateAlert(AlertDTO alert)
        {
            throw new NotImplementedException();
        }

        public Task<AlertDTO> UpdateAlert()
        {
            throw new NotImplementedException();
        }

        public Task<AlertDTO> DeleteAlert(int id)
        {
            throw new NotImplementedException();
        }
    }
}
