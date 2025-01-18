using FlightAlertData;
using FlightAlertLogic;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
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
        [Route("GetAlerts")]
        public IActionResult GetAlerts()
        {
            try
            {
                IQueryable<AlertDTO> alerts = _alertLogic.GetAlerts();

                if (alerts == null)
                {
                    return NotFound();
                }

                return Ok(JsonConvert.SerializeObject(alerts));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return Problem(detail: "An error occurred while getting alerts: " + ex.Message, statusCode: 500);
            }
        }

        [HttpGet]
        [Route("GetAlert")]
        public async Task<IActionResult> GetAlert([FromQuery] int id)
        {
            try
            {
                AlertDTO alert = await _alertLogic.GetAlert(id);

                if (alert == null)
                {
                    return NotFound();
                }

                return Ok(JsonConvert.SerializeObject(alert));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return Problem(detail: $"An error occurred while getting alert with id '{id}': " + ex.Message, statusCode: 500);
            }
        }

        [HttpPost]
        [Route("CreateAlert")]
        public async Task<IActionResult> CreateAlert(AlertDTO alert)
        {
            try
            {
                await _alertLogic.CreateAlert(alert);

                return CreatedAtAction(nameof(CreateAlert), new { id = alert.AlertId }, alert);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return Problem(detail: $"An error occurred while creating alert with id '{alert.AlertId}': " + ex.Message, statusCode: 500);
            }
        }

        //[HttpPut]
        //[Route("UpdateAlert")]
        //public async Task<IActionResult> UpdateAlert(int id, Alert alert)
        //{
        //    if (id != alert.AlertId)
        //    {
        //        return BadRequest("Alert ID mismatch.");
        //    }
        //
        //    _context.Entry(alert).State = EntityState.Modified;
        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (Exception ex)
        //    {
        //        return Problem("An error occurred while updating the alert: " + ex.Message);
        //    }
        //
        //    return NoContent();
        //}
        //
        //[HttpDelete]
        //[Route("DeleteAlert")]
        //public async Task<IActionResult> DeleteAlert(int id)
        //{
        //    var alert = await _context.Alerts.FindAsync(id);
        //    if (alert == null)
        //    {
        //        return NotFound();
        //    }
        //
        //    _context.Alerts.Remove(alert);
        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (Exception ex)
        //    {
        //        return Problem("An error occurred while deleting the alert: " + ex.Message);
        //    }
        //
        //    return NoContent();
        //}
    }

}
