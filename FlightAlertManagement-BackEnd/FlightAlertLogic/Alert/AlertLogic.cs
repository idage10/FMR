using FlightAlertData.Alert;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FlightAlertLogic.Alert
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

        public async Task<bool> CreateAlert(AlertDTO alert)
        {
            return await _alertData.CreateAlert(alert);
        }

        public async Task<bool> UpdateAlert(AlertDTO alert)
        {
            return await _alertData.UpdateAlert(alert);
        }

        public async Task<bool> DeleteAlert(int id)
        {
            return await _alertData.DeleteAlert(id);
        }
    }
}
