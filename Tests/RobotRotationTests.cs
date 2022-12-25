using MartianRobots.Models;
using MartianRobots.Services.Implementation;

namespace Tests
{
    public class RobotRotationTests
    {
        [Test]
        public void ShouldRotateCorrectly()
        {
            var robotRotation = new RobotRotation();

            var res = robotRotation.Rotate(Commands.L, Direction.N);
            Assert.That(res, Is.EqualTo(Direction.W));

            res = robotRotation.Rotate(Commands.L, Direction.W);
            Assert.That(res, Is.EqualTo(Direction.S));

            res = robotRotation.Rotate(Commands.L, Direction.S);
            Assert.That(res, Is.EqualTo(Direction.E));

            res = robotRotation.Rotate(Commands.L, Direction.E);
            Assert.That(res, Is.EqualTo(Direction.N));

            res = robotRotation.Rotate(Commands.R, Direction.N);
            Assert.That(res, Is.EqualTo(Direction.E));

            res = robotRotation.Rotate(Commands.R, Direction.E);
            Assert.That(res, Is.EqualTo(Direction.S));

            res = robotRotation.Rotate(Commands.R, Direction.S);
            Assert.That(res, Is.EqualTo(Direction.W));

            res = robotRotation.Rotate(Commands.R, Direction.W);
            Assert.That(res, Is.EqualTo(Direction.N));
        }

        [Test]
        public void ShouldThrowExceptionOnUnknownCommand()
        {
            var robotRotation = new RobotRotation();
            Assert.Throws<ArgumentException>(() => robotRotation.Rotate(Commands.F, Direction.E));
        }
    }
}