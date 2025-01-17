using FlightAlertData;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FlightAlertLogic
{
    public class AlertLogic : IAlertLogic
    {
        private readonly IAlertData _alertData;

        public AlertLogic(IAlertData alertData)
        {
            _alertData = alertData;
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
