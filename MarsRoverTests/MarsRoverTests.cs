using FluentAssertions;
using MarsRover;
using NUnit.Framework;

namespace MarsRoverTests
{
    public class MarsRoverTests
    {
        private readonly Rover _marsRover;
        public MarsRoverTests()
        {
            _marsRover = new Rover();
        }

        [TestCase(4, 8, 2, 3, "E", "LFRFF", ExpectedResult = "(4, 4, E)")]
        [TestCase(4, 8, 0, 2, "N", "FFLFRFF", ExpectedResult = "(0, 4, W) LOST")]
        public string TestRobot(int m, int n, int robotX, int robotY, string robotOrientation, string commands)
        {
            Grid grid = new Grid(m, n);
            Robot robot = new Robot(robotX, robotY, robotOrientation);
            foreach (char c in commands)
            {
                switch (c)
                {
                    case 'F':
                        robot.MoveForward(grid);
                        break;
                    case 'L':
                        robot.RotateLeft();
                        break;
                    case 'R':
                        robot.RotateRight();
                        break;
                }
            }
            return robot.ToString();
        }
    }
}


