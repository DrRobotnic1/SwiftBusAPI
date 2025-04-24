using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Services;
using System.Text.Json.Serialization;
using Services.BusServices;
using Domain.Models.BusModel.BusDto;

namespace SwiftBusAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BusController : ControllerBase
    {
        private readonly IBusService _busService;

        public BusController(IBusService busService)
        {
            _busService = busService;
        }

        [HttpGet("available-buses")]
        public async Task<ActionResult<BusJourneyDto>> GetBusJourney([FromQuery] BusAvailabilityFilterDto filter)
        {
            var availableBuses = await _busService.GetBusJourneyAsync(filter); 
            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve, 
                MaxDepth = 64  
            };           
          return Ok(availableBuses);
        }


       
        
    }
}
