namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandBuilders;

public class FileRenameCommandBuilder : ICommandBuilder
{
    private string? _path;
    private string? _name;

    public FileRenameCommandBuilder WithPath(string path)
    {
        _path = path;
        return this;
    }

    public FileRenameCommandBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public ICommand? Build()
    {
        if (string.IsNullOrEmpty(_path) || string.IsNullOrEmpty(_name))
            return null;

        return new FileRenameCommand(_path, _name);
    }
}