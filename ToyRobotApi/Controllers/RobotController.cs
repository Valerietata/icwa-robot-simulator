using Microsoft.AspNetCore.Mvc;

namespace ToyRobotApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RobotController : ControllerBase
    {
        private readonly Robot _robot;
        public RobotController(Robot robot)
        {
            _robot = robot;
        }
        // Need to provide x, y coordinates and facing direction for PLACE commands
        [HttpPost("place")]
        public IActionResult Place([FromBody] PlaceRequest request)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.Facing))
            {
                return BadRequest("Invalid request. Please provide x, y, and facing.");
            }
            _robot.Place(request.X, request.Y, request.Facing);
            return Ok(new { message = "Robot placed", state = _robot.Report() });
        }

        // Send request for the PLACE command
        public class PlaceRequest
        {
            public int X { get; set; }
            public int Y { get; set; }
            public string Facing { get; set; }
        }
    }
}
