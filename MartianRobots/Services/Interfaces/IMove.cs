using MartianRobots.Models;

namespace MartianRobots.Services.Interfaces
{
    public interface IMove
    {
        Point ProcessMove(Point p, Direction direction);
    }
}
