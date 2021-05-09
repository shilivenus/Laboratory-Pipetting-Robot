namespace Robot.Models
{
    public class Plate
    {
        public int[,] PlateStatus { get; set; }

        public Plate(int[,] plateStatus)
        {
            PlateStatus = plateStatus;
        }
    }
}
