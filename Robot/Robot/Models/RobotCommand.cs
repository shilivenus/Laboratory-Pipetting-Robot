using Robot.Models.Enum;

namespace Robot.Models
{
    public class RobotCommand
    {
        public CommandTypeEnum CommandName { get; set; }
        public Location Location { get; set; }
        public char? Direction { get; set; }
    }
}
