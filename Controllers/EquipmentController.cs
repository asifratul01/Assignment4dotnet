using Microsoft.AspNetCore.Mvc;
using AssignmentApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace AssignmentApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EquipmentController : ControllerBase
    {
        // Mock data for equipment
        private static readonly List<Equipment> EquipmentData = new List<Equipment>
        {
            new Equipment { CustomerId = 1, EquipmentList = new List<string> { "Hammer", "Drill", "Wrench" } },
            new Equipment { CustomerId = 2, EquipmentList = new List<string> { "Saw", "Screwdriver" } },
            new Equipment { CustomerId = 3, EquipmentList = new List<string> { "Ladder", "Level" } }
        };

        // GET: api/equipment
        [HttpGet]
        public IActionResult GetAllEquipment()
        {
            // Return all equipment data
            return Ok(EquipmentData.Select(e => new
            {
                customerId = e.CustomerId,
                equipment = e.EquipmentList
            }));
        }

        // GET: api/equipment/{customerId}
        [HttpGet("{customerId:int}")]
        public IActionResult GetEquipmentByCustomerId(int customerId)
        {
            // Validate the input
            if (customerId <= 0)
            {
                return BadRequest(new { error = "Invalid customer ID" });
            }

            // Find the customer equipment
            var customerEquipment = EquipmentData.FirstOrDefault(e => e.CustomerId == customerId);

            // Handle not found case
            if (customerEquipment == null)
            {
                return NotFound(new { error = $"Customer with ID {customerId} not found" });
            }

            // Return the equipment data
            return Ok(new
            {
                customerId = customerEquipment.CustomerId,
                equipment = customerEquipment.EquipmentList
            });
        }

        // GET: api/equipment/custom
        [HttpGet("custom")]
        public IActionResult GetCustomData()
        {
            // Example custom response
            return Ok(new
            {
                message = "This is a custom route for testing purposes.",
                equipmentCount = EquipmentData.Count,
                sampleEquipment = EquipmentData.SelectMany(e => e.EquipmentList).Take(3)
            });
        }

        // GET: /test
        [HttpGet("/test")]
        public IActionResult Test() => Ok("API is running");
    }
}
