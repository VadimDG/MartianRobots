namespace MartianRobots.Models
{
    public enum Direction
    {
        N = 0, S = 2, E = 1, W = 3
    }

    public enum Commands
    {
        F = 'F', L = 'L', R = 'R'
    }

    public static class Utils
    {
        public static Direction ConvertCharToDirection(char d)
        {
            switch (d)
            {
                case 'N': return Direction.N;
                case 'E': return Direction.E;
                case 'S': return Direction.S;
                case 'W': return Direction.W;
                default: throw new ArgumentException("Direction letter is not found");
            }
        }
    }
}
