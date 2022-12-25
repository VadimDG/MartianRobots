using MartianRobots.Dtos;
using MartianRobots.Models;
using MartianRobots.Services.Implementation;
using MartianRobots.Services.Interfaces;
using Moq;

namespace Tests
{
    public class IntegrationTests
    {
        [Test]
        public void ShouldSuccessfullyPassMovementWith1OffDefaultRotationMovement()
        {
            var data = new InputDto(5, 3, new List<RobotWrap>
                {
                    new RobotWrap { Robot = new Robot(1, 1, Utils.ConvertCharToDirection('E')), CommandLine = "RFRFRFRF" },
                    new RobotWrap { Robot = new Robot(3, 2, Utils.ConvertCharToDirection('N')), CommandLine = "FRRFLLFFRRFLL" },
                    new RobotWrap { Robot = new Robot(0, 3, Utils.ConvertCharToDirection('W')), CommandLine = "LLFFFLFLFL" }
                });
            var robots = data.Robots.ToList();

            var validatorMock = new Mock<IValidator>();
            validatorMock.Setup(x => x.IsValid()).Returns(true);

            var commandProcessor = new CommandProcessor(new RobotMoveProcessor(), new RobotRotation(), validatorMock.Object);
            var res = commandProcessor.ProcessRobotsGroup(robots, 5, 3).ToList();

            Assert.That(res[0], Is.EqualTo("1 1 E"));
            Assert.That(res[1], Is.EqualTo("3 3 N LOST"));
            Assert.That(res[2], Is.EqualTo("2 3 S"));
        }
    }
}