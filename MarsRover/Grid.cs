using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    public class Grid
    {
        public int M { get; }
        public int N { get; }

        public Grid(int m, int n)
        {
            if (m <= 0 && n <= 0)
            {
                throw new ArgumentException("Invalid grid size.");
            }

            M = m;
            N = n;
        }
    }
}
