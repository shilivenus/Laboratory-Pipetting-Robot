using Robot.Interface;
using Robot.Models;
using Robot.Models.Enum;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Robot.Reader
{
    public class FileReader : IFileReader
    {
        public IList<RobotCommand> GetCommands(string filePath)
        {
            var rawCommands = File.ReadAllLines(filePath).ToList();

            var robotCommands = new List<RobotCommand>();

            foreach(var rawCommand in rawCommands)
            {
                var robotCommand = new RobotCommand();
                if (rawCommand.Trim().Contains(","))
                {
                    var commdTypeString = rawCommand.Substring(0, 5);
                    robotCommand.CommandName = (CommandTypeEnum)Enum.Parse(typeof(CommandTypeEnum), commdTypeString, true);
                    var charArray = rawCommand.ToCharArray();
                    int x = (int)char.GetNumericValue(charArray[6]);
                    var y = (int)char.GetNumericValue(charArray[8]);
                    robotCommand.Location = new Location
                    {
                        X = x,
                        Y = y
                    };
                    robotCommands.Add(robotCommand);
                }
                else if (rawCommand.Trim().Contains(" "))
                {
                    var commdTypeString = rawCommand.Substring(0, 4);
                    robotCommand.CommandName = (CommandTypeEnum)Enum.Parse(typeof(CommandTypeEnum), commdTypeString, true);
                    var charArray = rawCommand.ToCharArray();
                    robotCommand.Direction = charArray[5];
                    robotCommands.Add(robotCommand);
                }
                else
                {
                    var commdTypeString = rawCommand.Trim();
                    robotCommand.CommandName = (CommandTypeEnum)Enum.Parse(typeof(CommandTypeEnum), commdTypeString, true);
                    robotCommands.Add(robotCommand);
                }
            }

            return robotCommands;
        }

        public IList<string> GetInitialPlateStatus(string filePath)
        {
            return File.ReadAllLines(filePath).ToList();
        }
    }
}
