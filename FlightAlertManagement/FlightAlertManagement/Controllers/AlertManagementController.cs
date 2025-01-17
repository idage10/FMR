using FlightAlertLogic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlightAlertManagement.Controllers
{
    [Route("Alerts/[controller]")]
    [ApiController]
    public class AlertManagementController : ControllerBase
    {
        private readonly IAlertLogic _alertLogic;

        public AlertManagementController(IAlertLogic alertLogic)
        {
            _alertLogic = alertLogic;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Alert>>> GetAlerts()
        {
            var alerts = await _context.Alerts.ToListAsync();
            if (alerts == null || !alerts.Any())
            {
                return NoContent();
            }
            return Ok(alerts);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Alert>> GetAlert(int id)
        {
            var alert = await _context.Alerts.FindAsync(id);

            if (alert == null)
            {
                return NotFound();
            }

            return Ok(alert);
        }

        [HttpPost]
        public async Task<ActionResult<Alert>> CreateAlert(Alert alert)
        {
            _context.Alerts.Add(alert);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return Problem("An error occurred while creating the alert: " + ex.Message);
            }

            return CreatedAtAction(nameof(GetAlert), new { id = alert.AlertId }, alert);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAlert(int id, Alert alert)
        {
            if (id != alert.AlertId)
            {
                return BadRequest("Alert ID mismatch.");
            }

            _context.Entry(alert).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return Problem("An error occurred while updating the alert: " + ex.Message);
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAlert(int id)
        {
            var alert = await _context.Alerts.FindAsync(id);
            if (alert == null)
            {
                return NotFound();
            }

            _context.Alerts.Remove(alert);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return Problem("An error occurred while deleting the alert: " + ex.Message);
            }

            return NoContent();
        }
    }

}
