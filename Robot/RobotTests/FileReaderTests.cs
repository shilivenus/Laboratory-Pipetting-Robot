using Robot.Reader;
using Xunit;

namespace RobotTests
{
    public class FileReaderTests
    {
        [Fact]
        public void GetCommands_TestFilePath_ReturnRobotCommandList()
        {
            //Arrange
            var reader = new FileReader();

            //Act
            var result = reader.GetCommands(@".\TestFile\TestInputFile.txt");

            //Asseert
            Assert.Equal("PLACE", result[0].CommandName.ToString());
            Assert.Equal(0, result[0].Location.X);
            Assert.Equal("MOVE", result[1].CommandName.ToString());
            Assert.Equal("N", result[1].Direction.ToString());
            Assert.Equal("REPORT", result[2].CommandName.ToString());
            Assert.Equal("PLACE", result[6].CommandName.ToString());
            Assert.Equal(1, result[6].Location.X);
        }
    }
}
