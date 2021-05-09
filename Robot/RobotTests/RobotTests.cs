using Robot.Models;
using Robot;
using System;
using Xunit;
using Robot.Models.Enum;

namespace RobotTests
{
    public class RobotTests
    {
        [Fact]
        public void Place_InvalidLocation_ReturnNull()
        {
            //Arrange
            var location = new Location
            {
                X = 5,
                Y = 0
            };

            var robot = new PipettingRobot();

            //Act
            var result = robot.Place(location);

            //Assert
            Assert.Null(result);
        }

        [Fact]
        public void Place_ValidLocation_ReturnLocation()
        {
            //Arrange
            var location = new Location
            {
                X = 4,
                Y = 0
            };

            var robot = new PipettingRobot();

            //Act
            var result = robot.Place(location);

            //Assert
            Assert.Equal(4, result.X);
            Assert.Equal(0, result.Y);
        }

        [Fact]
        public void Move_DirectionNorth_ReturnLocationMovedNorth()
        {
            //Arrange
            var robot = new PipettingRobot
            {
                CurrentLocation = new Location()
            };

            //Act
            var result = robot.Move(DirectionEnum.N);

            //Assert
            Assert.Equal(0, result.X);
            Assert.Equal(1, result.Y);
        }

        [Fact]
        public void Detect_StatusIsNull_ThrowError()
        {
            //Arrange
            var robot = new PipettingRobot();

            //Assert
            Assert.Throws<Exception>(() => robot.Detect());
        }

        [Fact]
        public void Detect_WellIsFull_ReturnTrue()
        {
            //Arrange
            var plateStatus = new int[5, 5];
            plateStatus[0, 0] = 1;

            var robot = new PipettingRobot
            {
                Plate = new Plate(plateStatus),
                CurrentLocation = new Location()
            };

            //Act
            var result = robot.Detect();

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void Detect_WellIsEmpty_ReturnFalse()
        {
            //Arrange
            var robot = new PipettingRobot
            {
                Plate = new Plate(new int[5,5]),
                CurrentLocation = new Location()
            };

            //Act
            var result = robot.Detect();

            //Assert
            Assert.False(result);
        }

        [Fact]
        public void Drop_WellIsEmpty_ReturnFilledPlate()
        {
            //Arrange
            var robot = new PipettingRobot
            {
                Plate = new Plate(new int[5, 5]),
                CurrentLocation = new Location()
            };

            //Act
            var result = robot.Drop();

            //Assert
            Assert.Equal(1, result.PlateStatus[0, 0]);
        }

        [Fact]
        public void Report_CurrentLocationIsFull_ReturnCurrentLocationStatus()
        {
            //Arrange
            var plateStatus = new int[5, 5];
            plateStatus[1, 2] = 1;

            var robot = new PipettingRobot
            {
                Plate = new Plate(plateStatus),
                CurrentLocation = new Location
                {
                    X = 1,
                    Y = 2
                }
            };

            //Act
            var result = robot.Report();

            //Assert
            Assert.Equal(1, result.Item1.X);
            Assert.Equal(2, result.Item1.Y);
            Assert.True(result.Item2);
        }

        [Fact]
        public void Report_CurrentLocationIsEmpty_ReturnCurrentLocationStatus()
        {
            //Arrange
            var robot = new PipettingRobot
            {
                Plate = new Plate(new int[5, 5]),
                CurrentLocation = new Location
                {
                    X = 1,
                    Y = 2
                }
            };

            //Act
            var result = robot.Report();

            //Assert
            Assert.Equal(1, result.Item1.X);
            Assert.Equal(2, result.Item1.Y);
            Assert.False(result.Item2);
        }
    }
}
