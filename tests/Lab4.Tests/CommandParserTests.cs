using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Core.IOSystem.FileShowModes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.IOSystem.FileSystemModes;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Handlers.CommandHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Handlers.CommandHandlers.QueryHandlers.Factories;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.Results;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests;

public class CommandParserTests
{
    [Fact]
    public void CommandConnect_WithModeTest()
    {
        // Arrange
        List<string> commands = ["connect", @"C:\Users\Eger\Desktop", "-m", "local"];
        ISubCommand handler = new DefaultSystemFactory().Create();
        var parser = new DefaultCommandParser(handler);

        // Act
        CommandParsingResult result = parser.Parse(commands);

        // Assert
        Assert.IsType<CommandParsingResult.Success>(result);
        if (result is CommandParsingResult.Success success)
        {
            Assert.IsType<ConnectCommand>(success.Command);
            var connectCommand = (ConnectCommand)success.Command;
            Assert.Equal(@"C:\Users\Eger\Desktop", connectCommand.DestinationPath);
            Assert.IsType<LocalFileSystemMode>(connectCommand.FileSystemMode);
        }
    }

    [Fact]
    public void ConnectCommand_WithoutMode_DefaultsToLocalTest()
    {
        // Arrange
        List<string> commands = ["connect", @"C:\Users\Eger\Desktop"];
        ISubCommand handler = new DefaultSystemFactory().Create();
        var parser = new DefaultCommandParser(handler);

        // Act
        CommandParsingResult result = parser.Parse(commands);

        // Assert
        Assert.IsType<CommandParsingResult.Success>(result);
        if (result is CommandParsingResult.Success success)
        {
            var connectCommand = (ConnectCommand)success.Command;
            Assert.IsType<LocalFileSystemMode>(connectCommand.FileSystemMode);
        }
    }

    [Fact]
    public void DisconnectCommand_ParsesCorrectlyTest()
    {
        // Arrange
        List<string> commands = ["disconnect"];
        ISubCommand handler = new DefaultSystemFactory().Create();
        var parser = new DefaultCommandParser(handler);

        // Act
        CommandParsingResult result = parser.Parse(commands);

        // Assert
        Assert.IsType<CommandParsingResult.Success>(result);
        if (result is CommandParsingResult.Success success)
        {
            Assert.IsType<DisconnectCommand>(success.Command);
        }
    }

    [Fact]
    public void TreeGotoCommand_ParsesCorrectlyTest()
    {
        // Arrange
        List<string> commands = ["tree", "goto", @"C:\Users"];
        ISubCommand handler = new DefaultSystemFactory().Create();
        var parser = new DefaultCommandParser(handler);

        // Act
        CommandParsingResult result = parser.Parse(commands);

        // Assert
        Assert.IsType<CommandParsingResult.Success>(result);
        if (result is CommandParsingResult.Success success)
        {
            Assert.IsType<TreeGoToCommand>(success.Command);
            var treeGoToCommand = (TreeGoToCommand)success.Command;
            Assert.Equal(@"C:\Users", treeGoToCommand.Path);
        }
    }

    [Fact]
    public void TreeListCommand_ParsesCorrectlyTest()
    {
        // Arrange
        List<string> commands = ["tree", "list", "-d", "2"];
        ISubCommand handler = new DefaultSystemFactory().Create();
        var parser = new DefaultCommandParser(handler);

        // Act
        CommandParsingResult result = parser.Parse(commands);

        // Assert
        Assert.IsType<CommandParsingResult.Success>(result);
        if (result is CommandParsingResult.Success success)
        {
            Assert.IsType<TreeListCommand>(success.Command);
            var treeListCommand = (TreeListCommand)success.Command;
            Assert.Equal(2, treeListCommand.Depth);
        }
    }

    [Fact]
    public void TreeListCommand_ParsesCorrectly_WithNegativeDepthTest()
    {
        // Arrange
        List<string> commands = ["tree", "list", "-d", "-2"];
        ISubCommand handler = new DefaultSystemFactory().Create();
        var parser = new DefaultCommandParser(handler);

        // Act
        CommandParsingResult result = parser.Parse(commands);

        // Assert
        Assert.IsType<CommandParsingResult.Success>(result);
        if (result is CommandParsingResult.Success success)
        {
            Assert.IsType<TreeListCommand>(success.Command);
            var treeListCommand = (TreeListCommand)success.Command;
            Assert.Equal(-2, treeListCommand.Depth);
        }
    }

    [Fact]
    public void TreeListCommand_WithoutDepth_ShouldFailTest()
    {
        // Arrange
        List<string> commands = ["tree", "list"];
        ISubCommand handler = new DefaultSystemFactory().Create();
        var parser = new DefaultCommandParser(handler);

        // Act
        CommandParsingResult result = parser.Parse(commands);

        // Assert
        Assert.IsType<CommandParsingResult.Failure>(result);
    }

    [Fact]
    public void FileShowCommand_ParsesCorrectlyTest()
    {
        // Arrange
        List<string> commands = ["file", "show", @"C:\file.txt", "-m", "console"];
        ISubCommand handler = new DefaultSystemFactory().Create();
        var parser = new DefaultCommandParser(handler);

        // Act
        CommandParsingResult result = parser.Parse(commands);

        // Assert
        Assert.IsType<CommandParsingResult.Success>(result);
        if (result is CommandParsingResult.Success success)
        {
            Assert.IsType<FileShowCommand>(success.Command);
            var fileShowCommand = (FileShowCommand)success.Command;
            Assert.Equal(@"C:\file.txt", fileShowCommand.Path);
            Assert.IsType<ConsoleFileShowMode>(fileShowCommand.FileShowMode);
        }
    }

    [Fact]
    public void FileShowCommand_WithoutMode_Test()
    {
        // Arrange
        List<string> commands = ["file", "show", @"C:\file.txt"];
        ISubCommand handler = new DefaultSystemFactory().Create();
        var parser = new DefaultCommandParser(handler);

        // Act
        CommandParsingResult result = parser.Parse(commands);

        // Assert
        Assert.IsType<CommandParsingResult.Failure>(result);
    }

    [Fact]
    public void FileMoveCommand_ParsesCorrectlyTest()
    {
        // Arrange
        List<string> commands = ["file", "move", @"C:\source.txt", @"C:\destination"];
        ISubCommand handler = new DefaultSystemFactory().Create();
        var parser = new DefaultCommandParser(handler);

        // Act
        CommandParsingResult result = parser.Parse(commands);

        // Assert
        Assert.IsType<CommandParsingResult.Success>(result);
        if (result is CommandParsingResult.Success success)
        {
            Assert.IsType<FileMoveCommand>(success.Command);
            var fileMoveCommand = (FileMoveCommand)success.Command;
            Assert.Equal(@"C:\source.txt", fileMoveCommand.SourcePath);
            Assert.Equal(@"C:\destination", fileMoveCommand.DestinationPath);
        }
    }

    [Fact]
    public void FileCopyCommand_ParsesCorrectlyTest()
    {
        // Arrange
        List<string> commands = ["file", "copy", @"C:\source.txt", @"C:\destination"];
        ISubCommand handler = new DefaultSystemFactory().Create();
        var parser = new DefaultCommandParser(handler);

        // Act
        CommandParsingResult result = parser.Parse(commands);

        // Assert
        Assert.IsType<CommandParsingResult.Success>(result);
        if (result is CommandParsingResult.Success success)
        {
            Assert.IsType<FileCopyCommand>(success.Command);
            var fileCopyCommand = (FileCopyCommand)success.Command;
            Assert.Equal(@"C:\source.txt", fileCopyCommand.SourcePath);
            Assert.Equal(@"C:\destination", fileCopyCommand.DestinationPath);
        }
    }

    [Fact]
    public void FileDeleteCommand_ParsesCorrectlyTest()
    {
        // Arrange
        List<string> commands = ["file", "delete", @"C:\file.txt"];
        ISubCommand handler = new DefaultSystemFactory().Create();
        var parser = new DefaultCommandParser(handler);

        // Act
        CommandParsingResult result = parser.Parse(commands);

        // Assert
        Assert.IsType<CommandParsingResult.Success>(result);
        if (result is CommandParsingResult.Success success)
        {
            Assert.IsType<FileDeleteCommand>(success.Command);
            var fileDeleteCommand = (FileDeleteCommand)success.Command;
            Assert.Equal(@"C:\file.txt", fileDeleteCommand.Path);
        }
    }

    [Fact]
    public void FileRenameCommand_ParsesCorrectlyTest()
    {
        // Arrange
        List<string> commands = ["file", "rename", @"C:\old.txt", "new.txt"];
        ISubCommand handler = new DefaultSystemFactory().Create();
        var parser = new DefaultCommandParser(handler);

        // Act
        CommandParsingResult result = parser.Parse(commands);

        // Assert
        Assert.IsType<CommandParsingResult.Success>(result);
        if (result is CommandParsingResult.Success success)
        {
            Assert.IsType<FileRenameCommand>(success.Command);
            var fileRenameCommand = (FileRenameCommand)success.Command;
            Assert.Equal(@"C:\old.txt", fileRenameCommand.Path);
            Assert.Equal("new.txt", fileRenameCommand.Name);
        }
    }

    [Fact]
    public void UnknownCommand_ReturnsFailureTest()
    {
        // Arrange
        List<string> commands = ["unknown", "command"];
        ISubCommand handler = new DefaultSystemFactory().Create();
        var parser = new DefaultCommandParser(handler);

        // Act
        CommandParsingResult result = parser.Parse(commands);

        // Assert
        Assert.IsType<CommandParsingResult.Failure>(result);
    }

    [Fact]
    public void EmptyCommand_ReturnsFailureTest()
    {
        // Arrange
        List<string> commands = [];
        ISubCommand handler = new DefaultSystemFactory().Create();
        var parser = new DefaultCommandParser(handler);

        // Act
        CommandParsingResult result = parser.Parse(commands);

        // Assert
        Assert.IsType<CommandParsingResult.Failure>(result);
    }

    [Fact]
    public void MultipleCommands_InSequence_ShouldWorkTest()
    {
        // Arrange
        ISubCommand handler = new DefaultSystemFactory().Create();
        var parser = new DefaultCommandParser(handler);

        // Act and Assert
        CommandParsingResult connectResult = parser.Parse(["connect", @"C:\test", "-m", "local"]);
        Assert.IsType<CommandParsingResult.Success>(connectResult);

        // Act and Assert
        CommandParsingResult gotoResult = parser.Parse(["tree", "goto", @"C:\test\subfolder"]);
        Assert.IsType<CommandParsingResult.Success>(gotoResult);

        // Act and Assert
        CommandParsingResult disconnectResult = parser.Parse(["disconnect"]);
        Assert.IsType<CommandParsingResult.Success>(disconnectResult);
    }

    [Fact]
    public void FileCommand_WithoutSubcommand_ReturnsFailureTest()
    {
        // Arrange
        List<string> commands = ["file"];
        ISubCommand handler = new DefaultSystemFactory().Create();
        var parser = new DefaultCommandParser(handler);

        // Act
        CommandParsingResult result = parser.Parse(commands);

        // Assert
        Assert.IsType<CommandParsingResult.Failure>(result);
    }
}