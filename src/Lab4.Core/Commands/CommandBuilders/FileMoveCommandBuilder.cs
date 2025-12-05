namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandBuilders;

public class FileMoveCommandBuilder : ICommandBuilder
{
    private string? _source;
    private string? _destination;

    public FileMoveCommandBuilder WithSource(string source)
    {
        _source = source;
        return this;
    }

    public FileMoveCommandBuilder WithDestination(string destination)
    {
        _destination = destination;
        return this;
    }

    public ICommand? Build()
    {
        if (string.IsNullOrEmpty(_source) || string.IsNullOrEmpty(_destination))
            return null;

        return new FileMoveCommand(_source, _destination);
    }
}