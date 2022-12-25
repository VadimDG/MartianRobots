using MartianRobots.Models;
using MartianRobots.Services.Interfaces;

namespace MartianRobots.Services.Implementation
{
    public class RobotRotation : IRotation
    {
        public Direction Rotate(Commands command, Direction d)
        {
            Direction newDir;
            if (command == Commands.R)
            {
                newDir = d == Direction.W ? Direction.N : ++d;
            }
            else if (command == Commands.L)
            {
                newDir = d == Direction.N ? Direction.W : --d;
            }
            else
            {
                throw new ArgumentException("Unknow rotation command");
            }

            return newDir;
        }
    }
}
