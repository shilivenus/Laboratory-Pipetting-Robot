using Robot.Interface;
using Robot.Models;
using Robot.Models.Enum;
using System;
using System.Collections.Generic;

namespace Robot
{
    public class PipettingRobot : IRobot
    {
        public Plate Plate { get; set; }
        public IList<RobotCommand> RobotCommands { get; set; }
        public Location CurrentLocation { get; set; }

        public Location Place(Location location)
        {
            if (location.X < 0 || location.X > 4 || location.Y < 0 || location.Y > 4)
                return null;

            CurrentLocation = location;

            return CurrentLocation;
        }

        public Location Move(DirectionEnum direction)
        {
            switch (direction)
            {
                case DirectionEnum.N:
                    if (CurrentLocation.Y + 1 <= 4)
                    {
                        CurrentLocation.Y = CurrentLocation.Y + 1;
                    }
                    break;
                case DirectionEnum.E:
                    if (CurrentLocation.X + 1 <= 4)
                    {
                        CurrentLocation.X = CurrentLocation.X + 1;
                    }
                    break;
                case DirectionEnum.S:
                    if (CurrentLocation.Y - 1 >= 0)
                    {
                        CurrentLocation.Y = CurrentLocation.Y - 1;
                    }
                    break;
                case DirectionEnum.W:
                    if (CurrentLocation.X - 1 >= 0)
                    {
                        CurrentLocation.X = CurrentLocation.X - 1;
                    }
                    break;
            }

            return CurrentLocation;
        }

        public bool Detect()
        {
            if(Plate?.PlateStatus == null)
            {
                Console.WriteLine("ERR");
                throw new Exception("robot cannot detect the plate");
            }

            return Plate.PlateStatus[CurrentLocation.X, CurrentLocation.Y] == 1;
        }

        public Plate Drop()
        {
            if (Plate.PlateStatus[CurrentLocation.X, CurrentLocation.Y] == 0)
                Plate.PlateStatus[CurrentLocation.X, CurrentLocation.Y] = 1;

            return Plate;
        }

        public Tuple<Location, bool> Report()
        {
            return new Tuple<Location, bool>(CurrentLocation, Detect());
        }
    }
}
