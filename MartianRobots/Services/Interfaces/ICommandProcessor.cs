using MartianRobots.Models;

namespace MartianRobots.Services.Interfaces
{
    public interface ICommandProcessor
    {
        IEnumerable<string> ProcessRobotsGroup(IEnumerable<RobotWrap> robots, int boardX, int boardY);
    }
}
