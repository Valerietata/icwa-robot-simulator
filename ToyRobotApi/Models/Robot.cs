using System;
namespace ToyRobotApi.Models
{
    //Set up the basic Direction enum for the robot    
    public enum Direction
    {
        NORTH,
        EAST,
        SOUTH,
        WEST
    }

    public class Robot
    {
        private readonly int tableSize;
        // Track if the robot has been placed on the board
        public bool Placed { get; private set; }
        // Current position and orientation
        public int? X { get; private set; }
        public int? Y { get; private set; }
        public Direction? Facing { get; private set; }
        // Set table size
        public Robot(int tableSize = 5)
        {
            this.tableSize = tableSize;
            Placed = false;
        }
        // Added Place method to position the robot on the board
        public void Place(int x, int y, string facingStr)
        {
            if (!Enum.TryParse<Direction>(facingStr.ToUpper(), out var facing))
                return;
            if (!IsValidPosition(x, y))
                return;
            X = x;
            Y = y;
            Facing = facing;
            Placed = true;
        }

        // Helper method to check if position is in bounds
        private bool IsValidPosition(int x, int y)
        {
            return x >= 0 && x < tableSize && y >= 0 && y < tableSize;
        }
        
    }
}
