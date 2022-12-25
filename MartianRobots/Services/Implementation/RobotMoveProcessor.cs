using MartianRobots.Models;
using MartianRobots.Services.Interfaces;

namespace MartianRobots.Services.Implementation
{
    public class RobotMoveProcessor : IMove
    {
        public Point ProcessMove(Point p, Direction direction)
        {
            if (direction == Direction.N)
            {
                p.Y++;
            }
            if (direction == Direction.S)
            {
                p.Y--;
            }
            if (direction == Direction.E)
            {
                p.X++;
            }
            if (direction == Direction.W)
            {
                p.X--;
            }

            return p;
        }
    }
}
