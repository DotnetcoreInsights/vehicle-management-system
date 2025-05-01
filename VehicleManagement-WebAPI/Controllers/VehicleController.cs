using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using VehicleManagement_WebAPI.Models;
using VehicleManagement_WebAPI.Repository;

namespace VehicleManagement_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleRepository _repository;

        public VehicleController(IVehicleRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("GetAllVehicles")]
        public IActionResult GetAllVehicles()
        {
            var vehicles = _repository.GetAllVehicles();
            return Ok(vehicles);
        }

        [HttpGet("GetVehicleById")]
        public IActionResult GetVehicleById(int id)
        {
            var vehicles = _repository.GetVehicleById(id);
            return Ok(vehicles);
        }

        [HttpPost("AddVehicle")]
        public IActionResult AddVehicle(VehicleModel vehicle)
        {
            _repository.AddVehicle(vehicle);
            return Ok("Added Successfully!");
        }

        [HttpPut("UpdateVehicle")]
        public IActionResult UpdateVehicle(VehicleModel vehicle)
        {
            if(vehicle.Id <= 0)
            {
                return BadRequest("Please provide a valid vehicle id");
            }
            bool isUpdated = _repository.UpdateVehicle(vehicle);
            if (isUpdated)
            {
                return Ok("Vehicle updated successfully");
            }
            else
            {
                return NotFound("Vehicle not found");
            }
        }

        [HttpDelete("DeleteVehicle")]
        public IActionResult DeletVehicle(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Please provide a valid vehicle id");
            }
            bool isDeleted = _repository.DeleteVehicle(id);
            if (isDeleted)
            {
                return Ok("Vehicle deleted successfully");
            }
            else
            {
                return NotFound("vehicle not found");
            }
        }

        [HttpPatch("PatchVehicle/{id}")]
        public IActionResult PatchVehicle(int id, JsonPatchDocument<VehicleModel> patchDoc)
        {
            if(id <= 0)
            {
                return BadRequest("Please provide a valid vehicle id");
            }
            if(patchDoc == null)
            {
                return BadRequest("Invalid patch Document");
            }
            bool isPatched = _repository.PatchVehicle(id, patchDoc);
            if(isPatched)
            {
                return Ok("Vehicle information patched successfully");
            }
            else
            {
                return NotFound("Vehicle not found");
            }
        }

    }
}
