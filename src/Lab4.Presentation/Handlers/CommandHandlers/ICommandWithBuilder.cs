using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Handlers.Arguments;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Handlers.CommandHandlers;

public interface ICommandWithBuilder<TBuilder> : INameCommand where TBuilder : ICommandBuilder
{
    ICommandWithBuilder<TBuilder> AddSubCommand(INameCommand handler);

    ICommandWithBuilder<TBuilder> AddPositionalArgument(IPositionalArgument<TBuilder> positionalArgument);

    ICommandWithBuilder<TBuilder> AddFlagArgument(IFlagArgument<TBuilder> argumentWithName);
}