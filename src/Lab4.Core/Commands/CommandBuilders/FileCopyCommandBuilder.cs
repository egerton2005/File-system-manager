namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandBuilders;

public class FileCopyCommandBuilder : ICommandBuilder
{
    private string? _source;
    private string? _destination;

    public FileCopyCommandBuilder WithSource(string source)
    {
        _source = source;
        return this;
    }

    public FileCopyCommandBuilder WithDestination(string destination)
    {
        _destination = destination;
        return this;
    }

    public ICommand? Build()
    {
        if (string.IsNullOrEmpty(_source) || string.IsNullOrEmpty(_destination))
            return null;

        return new FileCopyCommand(_source, _destination);
    }
}