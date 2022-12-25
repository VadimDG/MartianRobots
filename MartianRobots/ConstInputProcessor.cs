using MartianRobots.Dtos;
using MartianRobots.Models;
using MartianRobots.Services.Interfaces;

namespace MartianRobots
{
    public class ConstInputProcessor : IInputProcessor
    {
        public InputDto ProcessInput()
        {
            return new InputDto(5, 3, new List<RobotWrap>
                {
                    new RobotWrap { Robot = new Robot(1, 1, Utils.ConvertCharToDirection('E')), CommandLine = "RFRFRFRF" },
                    new RobotWrap { Robot = new Robot(3, 2, Utils.ConvertCharToDirection('N')), CommandLine = "FRRFLLFFRRFLL" },
                    new RobotWrap { Robot = new Robot(0, 3, Utils.ConvertCharToDirection('W')), CommandLine = "LLFFFLFLFL" }
                });
        }
    }
}
