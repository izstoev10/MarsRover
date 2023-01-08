namespace MarsRover
{
    public class Rover
    {
        public Robot[] ProcessInput()
        {
            // Parse the input
            string[] inputs = Console.ReadLine().Split();
            int m;
            int.TryParse(inputs[0], out m);
            int n;
            int.TryParse(inputs[1], out n);
            ValidateGrid(m, n);

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
                int x;
                int.TryParse(inputs[0].Trim('(', ','), out x);
                int y;
                int.TryParse(inputs[1].Trim(','), out y);
                string orientation = inputs[2].Trim(')');
                ValidateInitialPosition(x, y, orientation, m, n);
                string commands = inputs[3];
                Robot robot = new Robot(x, y, orientation);
                robots = robots.Concat(new[] { robot }).ToArray();
                ExecuteRobotCommands(grid, commands, robot);
            }
            return robots;
        }

        private static void ValidateGrid(int m, int n)
        {
            if (m <= 0 || n <= 0)
            {
                Console.WriteLine("Invalid grid size. M and N must be greater than 0. Please check the input or format");
                Environment.Exit(0);
            }
        }

        private static void ValidateInitialPosition(int x, int y, string orientation, int m, int n)
        {
            if(x > m || y > n)
            {
                Console.WriteLine("X and Y must be in the grid");
                Environment.Exit(0);
            }
            if (x < 0 || y < 0)
            {
                Console.WriteLine("X and Y must be greater than or equal to zero. Please check the input or format");
                Environment.Exit(0);
            }
            if(orientation != "N" && orientation != "S" && orientation != "W" && orientation != "E")
            {
                Console.WriteLine("Robot orientation must be one of the following N, S, E, W. Please check the input or format");
                Environment.Exit(0);
            }
        }

        private static void ExecuteRobotCommands(Grid grid, string commands, Robot robot)
        {
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

        public void ReturnRobots(Robot[] robots)
        {
            foreach (Robot robot in robots)
            {
                Console.WriteLine(robot);
            }
        }
    }
}
