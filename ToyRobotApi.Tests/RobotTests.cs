using Xunit;
using ToyRobotApi.Models;

namespace ToyRobotApi.Tests
{
    public class RobotTests
    {
        [Fact]
        public void TestPlaceAndReport()
        {
            var robot = new Robot();
            robot.Place(0, 0, "NORTH");
            Assert.Equal("0, 0, NORTH", robot.Report());
        }

        [Fact]
        public void TestMoveWithoutPlace()
        {
            var robot = new Robot();
            // Call move without ever calling place.
            robot.Move();
            Assert.Equal("Robot not placed", robot.Report());
        }


        [Fact]
        public void TestMoveWithinBounds()
        {
            var robot = new Robot();
            robot.Place(0, 0, "NORTH");
            robot.Move();
            Assert.Equal("0, 1, NORTH", robot.Report());
        }

        [Fact]
        public void TestPreventFallingOff()
        {
            var robot = new Robot();
            // Place the robot at the top edge.
            robot.Place(0, 4, "NORTH");
            robot.Move();
            // Since moving north would fall off, the position remains unchanged.
            Assert.Equal("0, 4, NORTH", robot.Report());
        }

        [Fact]
        public void TestLeftCommand()
        {
            var robot = new Robot();
            robot.Place(0, 0, "NORTH");
            robot.Left();
            Assert.Equal("0, 0, WEST", robot.Report());
        }

        [Fact]
        public void TestRightCommand()
        {
            var robot = new Robot();
            robot.Place(0, 0, "NORTH");
            robot.Right();
            Assert.Equal("0, 0, EAST", robot.Report());
        }

        [Fact]
        public void TestCommandSequence()
        {
            // Sequence: PLACE 1,2,EAST -> MOVE -> MOVE -> LEFT -> MOVE
            var robot = new Robot();
            robot.Place(1, 2, "EAST");
            robot.Move(); 
            robot.Move();  
            robot.Left();  
            robot.Move(); 
            Assert.Equal("3, 3, NORTH", robot.Report());
        }

        [Fact]
        public void TestInvalidMoveFollowedByValidMove()
        {
            var robot = new Robot();
            robot.Place(0, 4, "NORTH");
            robot.Move();
            // The position remains unchanged because this move is prevented.
            Assert.Equal("0, 4, NORTH", robot.Report());
            // Now execute a valid command: turn right to face east, then move.
            robot.Right();
            robot.Move();
            Assert.Equal("1, 4, EAST", robot.Report());
        }

    }
}
