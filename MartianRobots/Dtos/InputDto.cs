using MartianRobots.Models;

namespace MartianRobots.Dtos
{
    public class InputDto
    {
        public int XDymention { get; private set; }
        public int YDymention { get; private set; }
        public IEnumerable<RobotWrap> Robots { get; private set; }

        public InputDto(int x, int y, IEnumerable<RobotWrap> robots)
        {
            if (x < 0)
            {
                throw new ArgumentOutOfRangeException("x");
            }
            if (y < 0)
            {
                throw new ArgumentOutOfRangeException("y");
            }

            XDymention = x;
            YDymention = y;
            Robots = robots;
        }
    }
}
