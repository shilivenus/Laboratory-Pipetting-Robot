using Robot.Interface;
using Robot.Models;
using Robot.Models.Enum;
using System;
using System.Collections.Generic;

namespace Robot
{
    public class RobotRunner : IRobotRunner
    {
        private readonly IFileReader _fileReader;
        private IRobot _robot;

        public RobotRunner(IFileReader fileReader, IRobot robot)
        {
            _fileReader = fileReader;
            _robot = robot;
        }

        /// <summary>
        /// Inital plate and Excute commands
        /// </summary>
        public void Excute()
        {            
            var initalPlateStatus = _fileReader.GetInitialPlateStatus(@".\InputFile\InitialPlate.txt");
            var initalPlate = InitialPlate(initalPlateStatus);
            var plate = new Plate(initalPlate);

            _robot.Plate = plate;
            _robot.CurrentLocation = new Location();
            _robot.RobotCommands = _fileReader.GetCommands(@".\\InputFile\\InputFile.txt");

            foreach(var command in _robot.RobotCommands)
            {
                ExcuteCommand(command);
            }
        }

        private void Print(Tuple<Location, bool> status)
        {
            var isFull = status.Item2 ? "FULL" : "EMPTY";
            Console.WriteLine($"{status.Item1.X},{status.Item1.Y},{isFull}");
        }

        private void ExcuteCommand(RobotCommand command)
        {
            switch(command.CommandName)
            {
                case CommandTypeEnum.PLACE:
                    var placeLocation = command.Location;
                    _robot.Place(placeLocation);
                    break;
                case CommandTypeEnum.MOVE:
                    _robot.Move((DirectionEnum)Enum.Parse(typeof(DirectionEnum), command.Direction.ToString()));
                    break;
                case CommandTypeEnum.DETECT:
                    _robot.Detect();
                    break;
                case CommandTypeEnum.DROP:
                    _robot.Drop();
                    break;
                case CommandTypeEnum.REPORT:
                    var status = _robot.Report();
                    Print(status);
                    break;
            }
        }

        private int[,] InitialPlate(IList<string> initialStatus)
        {
            var plate = new int[5, 5];

            for(var i = 0; i <5; i++ )
            {
                for(var j = 0; j < 5; j++)
                {
                    var temp = initialStatus[0];
                    plate[i, j] = Convert.ToInt32(temp);
                    initialStatus.Remove(temp);
                }
            }

            return plate;
        }
    }
}
