namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandBuilders;

public class FileDeleteCommandBuilder : ICommandBuilder
{
    private string? _path;

    public FileDeleteCommandBuilder WithPath(string path)
    {
        _path = path;
        return this;
    }

    public ICommand? Build()
    {
        if (string.IsNullOrEmpty(_path))
            return null;

        return new FileDeleteCommand(_path);
    }
}