using Itmo.ObjectOrientedProgramming.Lab4.Core.IOSystem.FileShowModes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandBuilders;

public class FileShowCommandBuilder : ICommandBuilder
{
    private string? _path;
    private IFileShowMode? _fileShowMode;

    public FileShowCommandBuilder WithPath(string path)
    {
        _path = path;
        return this;
    }

    public FileShowCommandBuilder WithMode(IFileShowMode fileShowMode)
    {
        _fileShowMode = fileShowMode;
        return this;
    }

    public ICommand? Build()
    {
        if (string.IsNullOrEmpty(_path) || _fileShowMode is null)
            return null;

        return new FileShowCommand(_path, _fileShowMode);
    }
}