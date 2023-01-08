using MarsRover;

namespace MarsRoverTests
{
    public class MarsRoverTests
    {
        [TestCase(4, 8, 2, 3, "E", "LFRFF", ExpectedResult = "(4, 4, E)")]
        [TestCase(4, 8, 2, 2, "E", "LFRFF", ExpectedResult = "(4, 3, E)")]
        [TestCase(4, 8, 0, 2, "N", "FFLFRFF", ExpectedResult = "(0, 4, W) LOST")]
        [TestCase(4, 8, 3, 3, "S", "FFRFLF", ExpectedResult = "(2, 0, S)")]
        [TestCase(4, 8, 3, 3, "W", "FFLFLFF", ExpectedResult = "(3, 2, E)")]
        [TestCase(4, 8, 1, 1, "N", "FF", ExpectedResult = "(1, 3, N)")]
        [TestCase(4, 8, 1, 1, "E", "FF", ExpectedResult = "(3, 1, E)")]
        [TestCase(4, 8, 1, 1, "S", "FF", ExpectedResult = "(1, 0, S) LOST")]
        [TestCase(4, 8, 1, 1, "W", "FF", ExpectedResult = "(0, 1, W) LOST")]
        [TestCase(4, 8, 0, 0, "N", "", ExpectedResult = "(0, 0, N)")]
        [TestCase(4, 8, 0, 0, "E", "", ExpectedResult = "(0, 0, E)")]
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


