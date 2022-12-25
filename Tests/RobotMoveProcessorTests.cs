using MartianRobots.Models;
using MartianRobots.Services.Implementation;

namespace Tests
{
    public class RobotMoveProcessorTests
    {
        [Test]
        public void ShouldSuccessfullyProcessMovement()
        {
            var robotMoveProcessor = new RobotMoveProcessor();

            var res = robotMoveProcessor.ProcessMove(new Point { X = 2, Y = 2 }, Direction.N);
            Assert.That(res, Is.EqualTo(new Point { X = 2, Y = 3 }));

            res = robotMoveProcessor.ProcessMove(new Point { X = 2, Y = 2 }, Direction.E);
            Assert.That(res, Is.EqualTo(new Point { X = 3, Y = 2 }));

            res = robotMoveProcessor.ProcessMove(new Point { X = 2, Y = 2 }, Direction.S);
            Assert.That(res, Is.EqualTo(new Point { X = 2, Y = 1 }));

            res = robotMoveProcessor.ProcessMove(new Point { X = 2, Y = 2 }, Direction.W);
            Assert.That(res, Is.EqualTo(new Point { X = 1, Y = 2 }));
        }
    }
}