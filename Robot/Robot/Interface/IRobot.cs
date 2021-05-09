using Robot.Models;
using Robot.Models.Enum;
using System;
using System.Collections.Generic;

namespace Robot.Interface
{
    public interface IRobot
    {
        Location CurrentLocation { get; set; }
        Plate Plate { get; set; }
        IList<RobotCommand> RobotCommands { get; set; }

        bool Detect();
        Plate Drop();
        Location Move(DirectionEnum direction);
        Location Place(Location location);
        Tuple<Location, bool> Report();
    }
}