namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandBuilders;

public class TreeGoToCommandBuilder : ICommandBuilder
{
    private string? _path;

    public TreeGoToCommandBuilder WithPath(string path)
    {
        _path = path;
        return this;
    }

    public ICommand? Build()
    {
        if (string.IsNullOrEmpty(_path))
            return null;

        return new TreeGoToCommand(_path);
    }
}