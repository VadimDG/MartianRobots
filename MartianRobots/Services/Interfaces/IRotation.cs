using MartianRobots.Models;

namespace MartianRobots.Services.Interfaces
{
    public interface IRotation
    {
        Direction Rotate(Commands command, Direction d);
    }
}
