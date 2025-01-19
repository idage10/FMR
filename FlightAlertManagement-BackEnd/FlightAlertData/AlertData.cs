using FlightAlertData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAlertData
{
    public class AlertData : IAlertData
    {
        private readonly FlightContext _flightContext;
        public AlertData(FlightContext flightContext)
        {
            _flightContext = flightContext;
        }

        public IQueryable<AlertDTO> GetAlerts()
        {
            IQueryable<AlertDTO> alerts = _flightContext.Alerts
                .Select(alert => new AlertDTO
                {
                    AlertId = alert.AlertId,
                    UserId = alert.UserId,
                    FlightSource = alert.FlightSource,
                    FlightDestination = alert.FlightDestination,
                    PriceThreshold = alert.PriceThreshold,
                    IsActive = alert.IsActive
                });

            if (alerts == null || !alerts.Any())
            {
                return null;
            }

            return alerts;
        }

        public async Task<AlertDTO> GetAlert(int id)
        {
            Alerts alerts = await _flightContext.Alerts.FindAsync(id);

            if (alerts == null)
            {
                return null;
            }

            AlertDTO alert = new AlertDTO
            {
                AlertId = alerts.AlertId,
                UserId = alerts.UserId,
                FlightSource = alerts.FlightSource,
                FlightDestination = alerts.FlightDestination,
                PriceThreshold = alerts.PriceThreshold,
                IsActive = alerts.IsActive
            };

            return alert;
        }

        public async Task<bool> CreateAlert(AlertDTO alert)
        {
            Alerts alertContext = new Alerts
            {
                AlertId = alert.AlertId,
                UserId = alert.UserId,
                FlightSource = alert.FlightSource,
                FlightDestination = alert.FlightDestination,
                PriceThreshold = alert.PriceThreshold,
                IsActive = alert.IsActive
            };

            _flightContext.Alerts.Add(alertContext);

            int result = await _flightContext.SaveChangesAsync();

            return result > 0; // Returns true if one or more state entries were written to the database
        }

        public async Task<bool> UpdateAlert(AlertDTO alert)
        {
            Alerts alertContext = new Alerts
            {
                AlertId = alert.AlertId,
                UserId = alert.UserId,
                FlightSource = alert.FlightSource,
                FlightDestination = alert.FlightDestination,
                PriceThreshold = alert.PriceThreshold,
                IsActive = alert.IsActive
            };

            _flightContext.Entry(alertContext).State = EntityState.Modified; 
            int result = await _flightContext.SaveChangesAsync();

            return result > 0; // Returns true if one or more state entries were written to the database
        }

        public async Task<bool> DeleteAlert(int id)
        {
            Alerts alert = await _flightContext.Alerts.FindAsync(id);
            if (alert == null)
            {
                return false;
            }

            _flightContext.Alerts.Remove(alert);
            int result = await _flightContext.SaveChangesAsync();

            return result > 0; // Returns true if one or more state entries were written to the database
        }
    }
}
