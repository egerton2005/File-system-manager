using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.Results;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Handlers.CommandHandlers;

public abstract class WithoutBuilderCommandBase : IWithoutBuilderCommand
{
    public abstract string Name { get; }

    private readonly Dictionary<string, INameCommand> _subCommands = new Dictionary<string, INameCommand>();

    public IWithoutBuilderCommand AddSubCommand(INameCommand link)
    {
        _subCommands[link.Name] = link;
        return this;
    }

    public CommandParsingResult Handle(IEnumerator<string> iterator)
    {
        if (_subCommands.Count == 0 || !iterator.MoveNext())
            return new CommandParsingResult.Failure(new UnknownArgumentError());

        string command = iterator.Current;
        foreach (INameCommand subCommand in _subCommands.Values)
        {
            if (subCommand.Name == command)
                return subCommand.Handle(iterator);
        }

        return new CommandParsingResult.Failure(new UnknownArgumentError());
    }
}