# Toy Robot API

This project is a simple REST API that simulates a toy robot on a 5x5 table. You can send commands to place the robot, move it, rotate it, and get its current position.
## Features
### Commands

The robot should be able to process the following commands:

#### PLACE X,Y,FACING

Puts the toy robot on the table in position X,Y and facing NORTH,
SOUTH, EAST, or WEST.
The origin (0,0) is considered to be the SOUTH WEST corner.
The first valid command to the robot is a PLACE command. After that,
any sequence of commands may be issued in any order, including
another PLACE command.
The application should discard all commands in the sequence until a
valid PLACE command has been executed.

#### MOVE

Moves the toy robot one unit forward in the direction it is currently
facing.

#### LEFT

Rotates the robot 90° anticlockwise without changing its position.

#### RIGHT

Rotates the robot 90° clockwise without changing its position.

#### REPORT

Outputs the X,Y, and F (facing direction) of the robot. Standard output
is sufficient.

### Constraints

The robot must be prevented from falling off the table. Any movement that
would result in the robot falling must be prevented, while allowing further valid
commands.
Input can be from a file or standard input, as the developer chooses.
Provide test data/results for the app and its logic.

## Getting Started

### Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/9.0) (make sure it's installed on your machine)
- A code editor (like Visual Studio Code)
- Git (to clone the repo)

### How to Install

1. **Clone the github repo**
2. **Build the project:**

```bash
dotnet build
```

3. **Running the Application**

 ```bash
   dotnet run --project ToyRobotApi
   ```

### API Endpoints

POST /api/robot/place: Places the robot on the tabletop
jsonCopy{
  "x": 0,
  "y": 0,
  "facing": "NORTH"
}
POST /api/robot/move: Moves the robot one unit forward
POST /api/robot/left: Rotates the robot 90 degrees to the left
POST /api/robot/right: Rotates the robot 90 degrees to the right
GET /api/robot/report: Returns the current position and orientation of the robot

### Run test

 ```bash
   dotnet test
   ```
- **TestPlaceAndReport:**  
  Checks that when you place the robot at (0,0) facing NORTH, it reports "0, 0, NORTH" as expected.

- **TestMoveWithoutPlace:**  
  Makes sure that if you call MOVE before placing the robot, nothing happens and it shows "Robot not placed".

- **TestMoveWithinBounds:**  
  Verifies that if you place the robot at (0,0) facing NORTH and then move it, it correctly moves to (0,1,NORTH).

- **TestPreventFallingOff:**  
  Ensures that if the robot is already at the top edge (like at (0,4) facing NORTH), a MOVE command won't let it fall off. It should just stay at (0,4,NORTH).

- **TestLeftCommand:**  
  Checks that if the robot is facing NORTH and you turn it left, it ends up facing WEST.

- **TestRightCommand:**  
  Checks that if the robot is facing NORTH and you turn it right, it ends up facing EAST.

- **TestCommandSequence:**  
  Runs a series of commands—PLACE 1,2,EAST, then MOVE, MOVE, LEFT, MOVE—and expects the final output to be "3, 3, NORTH".

- **TestInvalidMoveFollowedByValidMove:**  
  Verifies that if a MOVE command would make the robot fall off (like when it's at (0,4) facing NORTH), that move is ignored. Then, if you turn it right and move, it should correctly move to (1,4,EAST).

