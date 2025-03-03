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
        // POST: api/robot/move
        [HttpPost("move")]
        public IActionResult Move()
        {
            _robot.Move();
            return Ok(new { message = "Robot moved", state = _robot.Report() });
        }

        // POST: api/robot/left
        [HttpPost("left")]
        public IActionResult Left()
        {
            _robot.Left();
            return Ok(new { message = "Robot turned left", state = _robot.Report() });
        }

        // POST: api/robot/right
        [HttpPost("right")]
        public IActionResult Right()
        {
            _robot.Right();
            return Ok(new { message = "Robot turned right", state = _robot.Report() });
        }

        // GET: api/robot/report
        [HttpGet("report")]
        public IActionResult Report()
        {
            return Ok(new { state = _robot.Report() });
        }
    }
    // DTO for the PLACE function
    public class PlaceRequest
    {
        public int X { get; set; }
        public int Y { get; set; }
        public string Facing { get; set; }
    }
}
