using MarsRover;

namespace MarsRobots
{
    class Program
    {
        static void Main(string[] args)
        {
            Rover marsRover = new Rover();
            Robot[] robots = marsRover.ProcessInput();
            marsRover.ReturnRobots(robots);
        }
    }
}
