using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandBuilders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Handlers.CommandHandlers;

public abstract class SubCommandArgumentHandlerBase<TBuilder> : ISubCommandArgumentHandler<TBuilder> where TBuilder : ICommandBuilder
{
    protected ISubCommandArgumentHandler<TBuilder>? Next { get; private set; }

    public ISubCommandArgumentHandler<TBuilder> AddNext(ISubCommandArgumentHandler<TBuilder> link)
    {
        if (Next is null)
            Next = link;
        else
            Next.AddNext(link);

        return this;
    }

    public abstract TBuilder Handle(IEnumerator<string> iterator, TBuilder builder);
}
