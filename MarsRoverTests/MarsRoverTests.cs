using FluentAssertions;
using MarsRover;
using NUnit.Framework;

namespace MarsRoverTests
{
    public class RobotTests
    {
        [Test]
        public void TestMoveForward()
        {
            Grid grid = new Grid(5, 5);
            Robot robot = new Robot(0, 0, "E");

            // Test moving forward in different directions
            robot.MoveForward(grid);
            robot.X.Should().Be(1);
            robot.Y.Should().Be(0);

            robot.Orientation = "N";
            robot.MoveForward(grid);
            robot.X.Should().Be(1);
            robot.Y.Should().Be(1);

            robot.Orientation = "W";
            robot.MoveForward(grid);
            robot.X.Should().Be(0);
            robot.Y.Should().Be(1);

            robot.Orientation = "S";
            robot.MoveForward(grid);
            robot.X.Should().Be(0);
            robot.Y.Should().Be(0);
        }

        [Test]
        public void TestRotateLeft()
        {
            Grid grid = new Grid(5, 5);
            Robot robot = new Robot(0, 0, "E");

            robot.RotateLeft();
            robot.Orientation.Should().Be("N");

            robot.RotateLeft();
            robot.Orientation.Should().Be("W");

            robot.RotateLeft();
            robot.Orientation.Should().Be("S");

            robot.RotateLeft();
            robot.Orientation.Should().Be("E");
        }

        [Test]
        public void TestRotateRight()
        {
            // Initialize the robot
            Robot robot = new Robot(0, 0, "E");

            // Test rotating right in different directions
            robot.RotateRight();
            robot.Orientation.Should().Be("S");

            robot.RotateRight();
            robot.Orientation.Should().Be("W");

            robot.RotateRight();
            robot.Orientation.Should().Be("N");

            robot.RotateRight();
            robot.Orientation.Should().Be("E");
        }
    }
}
