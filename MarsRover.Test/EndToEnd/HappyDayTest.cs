using MarsRover.Parsers;
using MarsRover.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MarsRover.Orientations;

namespace MarsRover.Test.EndToEnd
{
  /// <summary>
  /// A more complicated Happy Day test
  /// </summary>
  [TestClass]
  public class RunnerTests
  {
    private readonly Mock<ICommandParser> m_commandParserMock = new Mock<ICommandParser>(MockBehavior.Strict);

    [TestInitialize]
    public void SetupCommandParserMock()
    {
      m_commandParserMock
        .Setup(x => x.ParseGrid(It.IsAny<string>()))
        .Returns(new Grid(10, 10));

      m_commandParserMock
        .Setup(x => x.ParseCommands(It.IsAny<string>()))
        .Returns(new[] { 
          Command.Left, 
          Command.Right, 
          Command.Forward, 
          Command.Forward, 
          Command.Left,
          Command.Forward,
          Command.Right,
          Command.Forward});

      m_commandParserMock
        .Setup(x => x.ParseRover(It.IsAny<string>()))
        .Returns(new MarsRover(new North(), new Position (3, 3)));
    }
    
    [TestMethod]
    public void HappyDay()
    {
      // Arrange
      var runner = new Runner(m_commandParserMock.Object);

      // Act
      var finalState = runner.Run("", "");

      // Assert
      Assert.AreEqual("(2, 6, N)", finalState.ToString());
    }
  }
}