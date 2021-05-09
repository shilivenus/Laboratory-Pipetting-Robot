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

        /// <summary>
        /// Place robot, if out of the boundaries return null
        /// </summary>
        /// <param name="location">current location of robot</param>
        /// <returns>Current Location</returns>
        public Location Place(Location location)
        {
            if (location.X < 0 || location.X > 4 || location.Y < 0 || location.Y > 4)
                return null;

            CurrentLocation = location;

            return CurrentLocation;
        }

        /// <summary>
        /// Move robot based on direction, each move
        /// command is one step only
        /// </summary>
        /// <param name="direction">move direction</param>
        /// <returns>Current Location</returns>
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

        /// <summary>
        /// DETECT will sense whether the well directly below is FULL, 
        /// EMPTY or ERR (if the robot cannot detect the plate)
        /// </summary>
        /// <returns>Well is full or not</returns>
        public bool Detect()
        {
            if(Plate?.PlateStatus == null)
            {
                Console.WriteLine("ERR");
                throw new Exception("robot cannot detect the plate");
            }

            return Plate.PlateStatus[CurrentLocation.X, CurrentLocation.Y] == 1;
        }

        /// <summary>
        /// Drop will make current empty well to be full
        /// </summary>
        /// <returns>Filled Plate</returns>
        public Plate Drop()
        {
            if (Plate.PlateStatus[CurrentLocation.X, CurrentLocation.Y] == 0)
                Plate.PlateStatus[CurrentLocation.X, CurrentLocation.Y] = 1;

            return Plate;
        }

        /// <summary>
        /// Report current well status
        /// </summary>
        /// <returns>Current Location & Well Status</returns>
        public Tuple<Location, bool> Report()
        {
            return new Tuple<Location, bool>(CurrentLocation, Detect());
        }
    }
}
