using MartianRobots.Dtos;
using MartianRobots.Models;
using MartianRobots.Services.Interfaces;

namespace MartianRobots
{
    public class ConsoleInputProcessor : IInputProcessor
    {
        public InputDto ProcessInput()
        {
            Console.WriteLine("Print board dymention (x y):");
            var l = Console.ReadLine();
            var dymention = l.Split(' ');

            if (dymention.Length != 2)
            {
                throw new ArgumentException("There should be x y int numbers");
            }

            var baordX = Convert.ToInt32(dymention[0]);
            var baordY = Convert.ToInt32(dymention[1]);

            var key = 'a';
            var robots = new List<RobotWrap>();
            while (key != (char)13)
            {
                Console.WriteLine("Print robot position and direction (x y direction):");
                l = Console.ReadLine();
                var robotPosition = l.Split(' ');

                if (dymention.Length != 3)
                {
                    throw new ArgumentException("There should be x y int numbers and direction char");
                }

                Console.WriteLine("Print robot commands:");
                l = Console.ReadLine();

                robots.Add(new RobotWrap { Robot = new Robot(Convert.ToInt32(robotPosition[0]), Convert.ToInt32(robotPosition[1]), 0), CommandLine = l });
            }

            return new InputDto(baordX, baordY, robots);
            
        }
    }
}
