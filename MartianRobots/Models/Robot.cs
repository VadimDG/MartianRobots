namespace MartianRobots.Models
{
    public class Robot
    {
        public Point InitialPosition { get; private set; }

        public Direction InitialDirection { get; private set; }

        public Robot(int positionX, int positionY, Direction initialDirection)
        {
            if (positionX < 0)
            {
                throw new ArgumentOutOfRangeException("position x");
            }

            if (positionY < 0)
            {
                throw new ArgumentOutOfRangeException("position y");
            }

            InitialPosition = new Point { X = positionX, Y = positionY };
            InitialDirection = initialDirection;
        }
    }
}
