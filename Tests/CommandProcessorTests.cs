using MartianRobots.Dtos;
using MartianRobots.Models;
using MartianRobots.Services.Implementation;
using MartianRobots.Services.Interfaces;
using Moq;

namespace Tests
{
    public class CommandProcessorTests
    {
        [Test]
        public void ShouldFinishOnSamePoint()
        {
            var data = new InputDto(5, 3, new List<RobotWrap>
                {
                    new RobotWrap { Robot = new Robot(1, 3, Utils.ConvertCharToDirection('S')), CommandLine = "F" },
                    new RobotWrap { Robot = new Robot(1, 1, Utils.ConvertCharToDirection('N')), CommandLine = "F" },

                });
            var robots = data.Robots.ToList();

            var validatorMock = new Mock<IValidator>();
            validatorMock.Setup(x => x.IsValid()).Returns(true);

            var commandProcessor = new CommandProcessor(new RobotMoveProcessor(), new RobotRotation(), validatorMock.Object);
            var res = commandProcessor.ProcessRobotsGroup(robots, 3, 3).ToList();

            Assert.That(res[0], Is.EqualTo("1 2 S"));
            Assert.That(res[1], Is.EqualTo("1 2 N"));
        }

        [Test]
        public void ShouldThrowExceptionOnUndefinedCommand()
        {
            var data = new InputDto(5, 3, new List<RobotWrap>
                {
                    new RobotWrap { Robot = new Robot(1, 1, Utils.ConvertCharToDirection('E')), CommandLine = "Q" }
                });
            var robots = data.Robots.ToList();

            var moveMock = new Mock<IMove>();
            moveMock.Setup(x => x.ProcessMove(It.IsAny<Point>(), It.IsAny<Direction>())).Returns(new Point());

            var rotateMock = new Mock<IRotation>();
            rotateMock.Setup(x => x.Rotate(It.IsAny<Commands>(), It.IsAny<Direction>())).Returns(new Direction());

            var validatorMock = new Mock<IValidator>();
            validatorMock.Setup(x => x.IsValid()).Returns(true);

            var commandProcessor = new CommandProcessor(moveMock.Object, rotateMock.Object, validatorMock.Object);

            Assert.Throws<ArgumentException>(() => commandProcessor.ProcessRobotsGroup(robots, 5, 3).ToList());
        }

        [Test]
        public void ShouldThrowExceptionOnInvalidInput()
        {
            var data = new InputDto(5, 3, new List<RobotWrap>
                {
                    new RobotWrap { Robot = new Robot(1, 1, Utils.ConvertCharToDirection('E')), CommandLine = "Q" }
                });
            var robots = data.Robots.ToList();

            var moveMock = new Mock<IMove>();
            moveMock.Setup(x => x.ProcessMove(It.IsAny<Point>(), It.IsAny<Direction>())).Returns(new Point());

            var rotateMock = new Mock<IRotation>();
            rotateMock.Setup(x => x.Rotate(It.IsAny<Commands>(), It.IsAny<Direction>())).Returns(new Direction());

            var validatorMock = new Mock<IValidator>();
            validatorMock.Setup(x => x.IsValid()).Returns(false);

            var commandProcessor = new CommandProcessor(moveMock.Object, rotateMock.Object, validatorMock.Object);

            Assert.Throws<ArgumentException>(() => commandProcessor.ProcessRobotsGroup(robots, 5, 3).ToList());
        }

        [Test]
        public void ShouldGotLostOnLeftBottomCorrner()
        {
            var data = new InputDto(2, 2, new List<RobotWrap>
                {
                    new RobotWrap { Robot = new Robot(0, 0, Utils.ConvertCharToDirection('S')), CommandLine = "F" }
                });
            var robots = data.Robots.ToList();

            var moveMock = new Mock<IMove>();
            moveMock.Setup(x => x.ProcessMove(It.IsAny<Point>(), It.IsAny<Direction>())).Returns(new Point { X = 0, Y = -1 });

            var rotateMock = new Mock<IRotation>();
            rotateMock.Setup(x => x.Rotate(It.IsAny<Commands>(), It.IsAny<Direction>())).Returns(new Direction());

            var validatorMock = new Mock<IValidator>();
            validatorMock.Setup(x => x.IsValid()).Returns(true);

            var commandProcessor = new CommandProcessor(moveMock.Object, rotateMock.Object, validatorMock.Object); 
            var res = commandProcessor.ProcessRobotsGroup(robots, 5, 3).ToList();
            Assert.That(res.FirstOrDefault(), Is.EqualTo("0 0 S LOST"));
        }

        [Test]
        public void ShouldGotLostOnRightTopCorrner()
        {
            var data = new InputDto(2, 2, new List<RobotWrap>
                {
                    new RobotWrap { Robot = new Robot(2, 2, Utils.ConvertCharToDirection('N')), CommandLine = "F" }
                });
            var robots = data.Robots.ToList();

            var moveMock = new Mock<IMove>();
            moveMock.Setup(x => x.ProcessMove(It.IsAny<Point>(), It.IsAny<Direction>())).Returns(new Point { X = 3, Y = 2 });

            var rotateMock = new Mock<IRotation>();
            rotateMock.Setup(x => x.Rotate(It.IsAny<Commands>(), It.IsAny<Direction>())).Returns(new Direction());

            var validatorMock = new Mock<IValidator>();
            validatorMock.Setup(x => x.IsValid()).Returns(true);

            var commandProcessor = new CommandProcessor(moveMock.Object, rotateMock.Object, validatorMock.Object);
            var res = commandProcessor.ProcessRobotsGroup(robots, 2, 2).ToList();
            Assert.That(res.FirstOrDefault(), Is.EqualTo("2 2 N LOST"));
        }
    }
}