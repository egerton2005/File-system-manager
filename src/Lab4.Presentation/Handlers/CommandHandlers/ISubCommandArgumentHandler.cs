using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandBuilders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Handlers.CommandHandlers;

public interface ISubCommandArgumentHandler<TBuilder> where TBuilder : ICommandBuilder
{
    ISubCommandArgumentHandler<TBuilder> AddNext(ISubCommandArgumentHandler<TBuilder> link);

    TBuilder Handle(IEnumerator<string> iterator, TBuilder builder);
}