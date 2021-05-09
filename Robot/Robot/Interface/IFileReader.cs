using Robot.Models;
using System.Collections.Generic;

namespace Robot.Interface
{
    public interface IFileReader
    {
        IList<RobotCommand> GetCommands(string filePath);
        IList<string> GetInitialPlateStatus(string filePath);
    }
}
