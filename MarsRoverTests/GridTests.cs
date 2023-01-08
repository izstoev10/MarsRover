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
        public void TestGridSizeWithOneValueBeingPositive()
        {
            Action action = () => new Grid(-1, 5);
            action.Should().Throw<ArgumentException>().WithMessage("Invalid grid size.");
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
