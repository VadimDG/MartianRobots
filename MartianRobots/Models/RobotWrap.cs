namespace MartianRobots.Models
{
    public class RobotWrap
    {
        public Robot Robot { get; init; } = new Robot(default, default, 0);
        public string CommandLine { get; init; } = string.Empty;
    }
}
