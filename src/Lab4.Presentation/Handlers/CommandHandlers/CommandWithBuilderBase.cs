using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Handlers.Arguments;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.Results;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Handlers.CommandHandlers;

public abstract class CommandWithBuilderBase<TBuilder> : ICommandWithBuilder<TBuilder> where TBuilder : ICommandBuilder, new()
{
    public abstract string Name { get; }

    private readonly Dictionary<string, INameCommand> _subCommands = new Dictionary<string, INameCommand>();

    private readonly List<IPositionalArgument<TBuilder>> _positionalArguments = new List<IPositionalArgument<TBuilder>>();

    private readonly Dictionary<string, IFlagArgument<TBuilder>> _flagArguments = new Dictionary<string, IFlagArgument<TBuilder>>();

    public ICommandWithBuilder<TBuilder> AddSubCommand(INameCommand handler)
    {
        _subCommands[handler.Name] = handler;
        return this;
    }

    public ICommandWithBuilder<TBuilder> AddPositionalArgument(IPositionalArgument<TBuilder> positionalArgument)
    {
        _positionalArguments.Add(positionalArgument);
        return this;
    }

    public ICommandWithBuilder<TBuilder> AddFlagArgument(IFlagArgument<TBuilder> argumentWithName)
    {
        _flagArguments[argumentWithName.Name] = argumentWithName;
        return this;
    }

    public CommandParsingResult Handle(IEnumerator<string> iterator)
    {
        if (_subCommands.Count > 0)
        {
            if (!iterator.MoveNext())
                return new CommandParsingResult.Failure(new NotEnoughArgumentsError());

            string subCommandName = iterator.Current;
            if (_subCommands.TryGetValue(subCommandName, out INameCommand? subCommand))
            {
                return subCommand.Handle(iterator);
            }

            return new CommandParsingResult.Failure(new UnknownArgumentError());
        }

        var builder = new TBuilder();

        foreach (IPositionalArgument<TBuilder> arg in _positionalArguments)
        {
            if (!iterator.MoveNext())
                return new CommandParsingResult.Failure(new NotEnoughArgumentsError());

            builder = arg.Handle(iterator, builder);
        }

        while (iterator.MoveNext())
        {
            string arg = iterator.Current;

            if (!arg.StartsWith('-'))
                return new CommandParsingResult.Failure(new UnknownArgumentError());

            if (!_flagArguments.TryGetValue(arg, out IFlagArgument<TBuilder>? flagArg))
                return new CommandParsingResult.Failure(new UnknownArgumentError());

            builder = flagArg.Handle(iterator, builder);
        }

        ICommand? command = builder.Build();
        if (command is null)
            return new CommandParsingResult.Failure(new NotEnoughArgumentsError());

        return new CommandParsingResult.Success(command);
    }
}
