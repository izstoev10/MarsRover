using FluentAssertions;
using MarsRover;

namespace MarsRoverTests
{
    public class RobotTests
    {
        [Test]
        public void TestMoveForward()
        {
            Grid grid = new Grid(5, 5);
            Robot robot = new Robot(0, 0, "E");

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
            Robot robot = new Robot(0, 0, "E");

            robot.RotateRight();
            robot.Orientation.Should().Be("S");

            robot.RotateRight();
            robot.Orientation.Should().Be("W");

            robot.RotateRight();
            robot.Orientation.Should().Be("N");

            robot.RotateRight();
            robot.Orientation.Should().Be("E");
        }

        [Test]
        public void TestInitializeRobotWithNegativeXandY()
        {
            Action action = () => new Robot(-1, -4, "E");
            action.Should().Throw<ArgumentException>().WithMessage("Invalid initial coordinates or orientation.");
        }

        [Test]
        public void TestInitializeRobotWithEmptyOrientaton()
        {
            Action action = () => new Robot(-1, -4, "");
            action.Should().Throw<ArgumentException>().WithMessage("Invalid initial coordinates or orientation.");
        }
    }
}
