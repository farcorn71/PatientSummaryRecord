using Microsoft.AspNetCore.Mvc;
using PatientSummaryRecord.API.Models;
using PatientSummaryRecord.Application.DTOs;
using PatientSummaryRecord.Application.Exceptions;
using PatientSummaryRecord.Application.Interfaces;
using PatientSummaryRecord.Application.Mapping.PatientSummaryRecord.Application.Mapping;

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

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PatientDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public IActionResult GetPatient(int id)
        {
            if (id <= 0)
                return BadRequest(new ErrorResponse
                {
                    StatusCode = 400,
                    Message = "Invalid patient ID. Must be a positive integer."
                });

            try { 
                var patient = _service.GetPatientSummary(id);
                if (patient == null)
                    return NotFound(new { Message = "Patient not found." });
                var patientDto = PatientMapper.MapToDto(patient);
                return Ok(patientDto);
            }
            catch (PatientNotFoundException ex)
            {
                return NotFound(new ErrorResponse
                {
                    StatusCode = 404,
                    Message = ex.Message
                });
            }

        }
    }
}
