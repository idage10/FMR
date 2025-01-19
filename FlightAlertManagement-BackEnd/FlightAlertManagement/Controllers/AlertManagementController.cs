using FlightAlertData.Alert;
using FlightAlertLogic.Alert;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
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
        public async Task<IActionResult> CreateAlert([FromBody] AlertDTO alert)
        {
            try
            {
                bool isSuccess = await _alertLogic.CreateAlert(alert);
                if (!isSuccess)
                {
                    return Problem(detail: "Failed to create alert.", statusCode: 500);
                }

                return CreatedAtAction(nameof(CreateAlert), new { id = alert.AlertId }, alert);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return Problem(detail: $"An error occurred while creating alert with id '{alert.AlertId}': " + ex.Message, statusCode: 500);
            }
        }

        [HttpPut]
        [Route("UpdateAlert")]
        public async Task<IActionResult> UpdateAlert([FromQuery] int id, [FromBody] AlertDTO alert)
        {
            if (id != alert.AlertId)
            {
                return BadRequest("Alert ID mismatch.");
            }
        
            try
            {
                bool isSuccess = await _alertLogic.UpdateAlert(alert);
                if (!isSuccess)
                {
                    return Problem(detail: "Failed to update alert.", statusCode: 500);
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return Problem(detail: $"An error occurred while updating alert with id '{alert.AlertId}': " + ex.Message, statusCode: 500);
            }
        }
        
        [HttpDelete]
        [Route("DeleteAlert")]
        public async Task<IActionResult> DeleteAlert([FromQuery] int id)
        {
            try
            {
                bool isSuccess = await _alertLogic.DeleteAlert(id);
                if (!isSuccess)
                {
                    return Problem(detail: $"Failed to delete alert with id {id}.", statusCode: 500);
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return Problem(detail: $"An error occurred while deleting alert with id '{id}': " + ex.Message, statusCode: 500);
            }
        }
    }

}
