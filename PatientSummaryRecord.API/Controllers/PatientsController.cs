using Microsoft.AspNetCore.Mvc;
using PatientSummaryRecord.Application.Interfaces;

namespace PatientSummaryRecord.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientService _service;

        public PatientsController(IPatientService service)
        {
            _service = service;
        }

        [HttpGet]
        [ActionName("Get")]
        public IActionResult Get()
        {
            return Ok("Success: This is a sample response - " + DateTime.Now.ToString("dd/MM/yyyy HH:mm")); ;
        }

        [HttpGet("{id}")]
        [ActionName("GetPatient")]
        [ProducesResponseType(typeof(Models.Covid19.RecordPaging), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        public IActionResult GetPatient(int id)
        {
            var patient = _service.GetPatientSummary(id);
            if (patient == null)
                return NotFound(new { Message = "Patient not found." });

            return Ok(patient);
        }
    }
}
