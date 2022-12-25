using MartianRobots.Models;
using MartianRobots.Services.Interfaces;

namespace MartianRobots.Services.Implementation
{
    public class CommandProcessor : ICommandProcessor
    {
        private readonly HashSet<BoarderPoints> _boarderPoints = new();
        private readonly IMove _moveProcessor;
        private readonly IRotation _rotation;
        private readonly IValidator _validator;

        public CommandProcessor(IMove moveProcessor, IRotation rotation, IValidator validator)
        {
            _moveProcessor = moveProcessor;
            _rotation = rotation;
            _validator = validator;
        }

        public IEnumerable<string> ProcessRobotsGroup(IEnumerable<RobotWrap> robots, int boardX, int boardY)
        {
            if (!_validator.IsValid())
            {
                throw new ArgumentException("Input parameters are invalid");
            }
            return robots.Select(el => ProcessCommands(el, boardX, boardY));
        }

        private string ProcessCommands(RobotWrap robotWrap, int boardX, int boardY)
        {
            var currentDirection = robotWrap.Robot.InitialDirection;
            var currentPosition = robotWrap.Robot.InitialPosition;

            foreach (var c in robotWrap.CommandLine)
            {
                if ((Commands)c == Commands.F)
                {
                    if (_boarderPoints.Contains(new BoarderPoints { p = currentPosition, d = currentDirection }))
                    {
                        continue;
                    }

                    var prevPos = currentPosition;
                    currentPosition = _moveProcessor.ProcessMove(currentPosition, currentDirection);
                    if (currentPosition.X > boardX || currentPosition.Y > boardY || currentPosition.X < 0 || currentPosition.Y < 0)
                    {
                        _boarderPoints.Add(new BoarderPoints { p = prevPos, d = currentDirection });
                        return $"{prevPos.X} {prevPos.Y} {currentDirection} LOST";
                    }
                    continue;
                }

                if ((Commands)c == Commands.L || (Commands)c == Commands.R)
                {
                    currentDirection = _rotation.Rotate((Commands)c, currentDirection);
                    continue;
                }

                throw new ArgumentException("Undefined command");
            }
            return $"{currentPosition.X} {currentPosition.Y} {currentDirection}";
        }
    }
}
