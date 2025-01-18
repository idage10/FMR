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

        public IQueryable<AlertDTO> GetAlerts()
        {
            return _alertData.GetAlerts();
        }

        public async Task<AlertDTO> GetAlert(int id)
        {
            return await _alertData.GetAlert(id);
        }

        public async Task CreateAlert(AlertDTO alert)
        {
            await _alertData.CreateAlert(alert);
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
