using Itmo.ObjectOrientedProgramming.Lab4.Core.IOSystem.FileSystemModes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandBuilders;

public class ConnectCommandBuilder : ICommandBuilder
{
    private string? _destinationPath;
    private IFileSystemMode _fileSystemMode;

    public ConnectCommandBuilder()
    {
        _fileSystemMode = new LocalFileSystemMode();
    }

    public ConnectCommandBuilder WithDestinationPath(string destinationPath)
    {
        _destinationPath = destinationPath;
        return this;
    }

    public ConnectCommandBuilder UpdateFileSystemMode(IFileSystemMode fileSystemMode)
    {
        _fileSystemMode = fileSystemMode;
        return this;
    }

    public ICommand? Build()
    {
        if (string.IsNullOrEmpty(_destinationPath))
            return null;

        return new ConnectCommand(_destinationPath, _fileSystemMode);
    }
}