namespace MarsRover
{
    public class Rover
    {
        public Robot[] ReadInputAndUpdateRobotPositionsAndOrientation()
        {
            // Parse the input
            string[] inputs = Console.ReadLine().Split();
            int m = int.Parse(inputs[0]);
            int n = int.Parse(inputs[1]);

            // Initialize the grid and robots
            Grid grid = new Grid(m, n);
            var robots = new Robot[0];

            string line = String.Empty;
            while (true)
            {
                line = Console.ReadLine();
                if (string.IsNullOrEmpty(line))
                {
                    break;
                }

                // Parse the initial state of the robot
                inputs = line.Split();
                int x = int.Parse(inputs[0].Trim('(', ','));
                int y = int.Parse(inputs[1].Trim(','));
                string orientation = inputs[2].Trim(')');
                string commands = inputs[3];

                Robot robot = new Robot(x, y, orientation);
                robots = robots.Concat(new[] { robot }).ToArray();

                // Execute the commands for the robot
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
            }
            return robots;
        }


        public void ReturnRobotsFinalPositionsAndOrientation(Robot[] robots)
        {
            foreach (Robot robot in robots)
            {
                Console.WriteLine(robot);
            }
        }
    }
}
