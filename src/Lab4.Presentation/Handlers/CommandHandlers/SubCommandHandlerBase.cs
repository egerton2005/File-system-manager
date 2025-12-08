using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.Results;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Handlers.CommandHandlers;

public abstract class SubCommandHandlerBase : ISubCommandHandler
{
    public abstract string Name { get; }

    protected ISubCommandHandler? Next { get; private set; }

    public ISubCommandHandler AddNext(ISubCommandHandler link)
    {
        if (Next is null)
            Next = link;
        else
            Next.AddNext(link);

        return this;
    }

    public abstract CommandParsingResult Handle(IEnumerator<string> iterator);
}