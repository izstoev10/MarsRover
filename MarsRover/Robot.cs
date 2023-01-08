using MarsRobots;

namespace MarsRover
{
    public class Robot
    {
        public int X { get; set; }
        public int Y { get; set; }
        public string Orientation { get; set; }
        public bool IsLost { get; set; }

        public Robot(int x, int y, string orientation)
        {
            X = x;
            Y = y;
            Orientation = orientation;
        }

        public void MoveForward(Grid grid)
        {
            if (IsLost)
            {
                return;
            }

            switch (Orientation)
            {
                case "N":
                    Y++;
                    if (Y > grid.N)
                    {
                        Y--;
                        IsLost = true;
                    }
                    break;
                case "E":
                    X++;
                    if (X > grid.M)
                    {
                        X--;
                        IsLost = true;
                    }
                    break;
                case "S":
                    Y--;
                    if (Y < 0)
                    {
                        Y++;
                        IsLost = true;
                    }
                    break;
                case "W":
                    X--;
                    if (X < 0)
                    {
                        X++;
                        IsLost = true;
                    }
                    break;
            }
        }

        public void RotateLeft()
        {
            if (IsLost)
            {
                return;
            }

            switch (Orientation)
            {
                case "N":
                    Orientation = "W";
                    break;
                case "E":
                    Orientation = "N";
                    break;
                case "S":
                    Orientation = "E";
                    break;
                case "W":
                    Orientation = "S";
                    break;
            }
        }

        public void RotateRight()
        {
            if (IsLost)
            {
                return;
            }

            switch (Orientation)
            {
                case "N":
                    Orientation = "E";
                    break;
                case "E":
                    Orientation = "S";
                    break;
                case "S":
                    Orientation = "W";
                    break;
                case "W":
                    Orientation = "N";
                    break;
            }
        }

        public override string ToString()
        {
            return $"({X}, {Y}, {Orientation}){(IsLost ? " LOST" : "")}";
        }
    }
}
