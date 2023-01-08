using FluentAssertions;
using MarsRover;

namespace MarsRoverTests
{
    public class GridTests
    {
        [Test]
        public void TestInvalidGridSize()
        {
            Action action = () => new Grid(-1, -1);
            action.Should().Throw<ArgumentException>().WithMessage("Invalid grid size.");
        } 
        
        [Test]
        public void TestGridSizeWithOneValueBeingZero()
        {
            Grid grid = new Grid(0, 1);
            grid.M.Should().Be(0);
            grid.N.Should().Be(1);
        }

        [Test]
        public void TestGridSizeWIthPositiveValues()
        {
            Grid grid = new Grid(5, 5);
            grid.M.Should().Be(5);
            grid.N.Should().Be(5);
        }
    }
}
