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

        // Moves the robot one unit in the current direction if not fall
        public void Move()
        {
            if (!Placed) return;

            int newX = X.Value;
            int newY = Y.Value;

            // Calculate new position based on current direction
            switch (Facing.Value)
            {
                case Direction.NORTH:
                    newY++;
                    break;
                case Direction.SOUTH:
                    newY--;
                    break;
                case Direction.EAST:
                    newX++;
                    break;
                case Direction.WEST:
                    newX--;
                    break;
            }

            // Only move if the new position is valid
            if (IsValidPosition(newX, newY))
            {
                X = newX;
                Y = newY;
            }
        }

        // Rotates the robot 90 degrees left
        public void Left()
        {
            if (!Placed) return;
            Facing = LeftDirection(Facing.Value);
        }

        // Rotates the robot 90 degrees right
        public void Right()
        {
            if (!Placed) return;
            Facing = RightDirection(Facing.Value);
        }

        private Direction LeftDirection(Direction current)
        {
            return current switch
            {
                Direction.NORTH => Direction.WEST,
                Direction.WEST => Direction.SOUTH,
                Direction.SOUTH => Direction.EAST,
                Direction.EAST => Direction.NORTH,
                _ => current
            };
        }

        private Direction RightDirection(Direction current)
        {
            return current switch
            {
                Direction.NORTH => Direction.EAST,
                Direction.EAST => Direction.SOUTH,
                Direction.SOUTH => Direction.WEST,
                Direction.WEST => Direction.NORTH,
                _ => current
            };
        }
    }
}
