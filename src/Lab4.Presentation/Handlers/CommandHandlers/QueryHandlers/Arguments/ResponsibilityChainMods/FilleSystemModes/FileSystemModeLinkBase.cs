using Itmo.ObjectOrientedProgramming.Lab4.Core.IOSystem.FileSystemModes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Handlers.CommandHandlers.QueryHandlers.Arguments.ResponsibilityChainMods.FilleSystemModes;

public abstract class FileSystemModeLinkBase : IFileSystemModeLink
{
    private IFileSystemModeLink? _next;

    public IFileSystemModeLink AddNext(IFileSystemModeLink link)
    {
        if (_next is null)
            _next = link;
        else
            _next.AddNext(link);

        return this;
    }

    public abstract IFileSystemMode? Apply(string name);

    protected IFileSystemMode? CallNext(string name)
    {
        return _next?.Apply(name);
    }
}