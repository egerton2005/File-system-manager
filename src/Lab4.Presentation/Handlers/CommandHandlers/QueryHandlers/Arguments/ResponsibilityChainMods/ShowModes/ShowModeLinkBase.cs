using Itmo.ObjectOrientedProgramming.Lab4.Core.IOSystem.FileShowModes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Handlers.CommandHandlers.QueryHandlers.Arguments.ResponsibilityChainMods.ShowModes;

public abstract class ShowModeLinkBase : IShowModeLink
{
    private IShowModeLink? _next;

    public IShowModeLink AddNext(IShowModeLink link)
    {
        if (_next is null)
            _next = link;
        else
            _next.AddNext(link);

        return this;
    }

    public abstract IFileShowMode? Apply(string name);

    protected IFileShowMode? CallNext(string name)
    {
        return _next?.Apply(name);
    }
}