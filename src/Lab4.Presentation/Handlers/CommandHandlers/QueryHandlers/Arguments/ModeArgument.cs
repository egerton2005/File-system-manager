using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Core.IOSystem.FileSystemModes;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Handlers.CommandHandlers.QueryHandlers.Arguments.ResponsibilityChainMods.FilleSystemModes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Handlers.CommandHandlers.QueryHandlers.Arguments;

public class ModeArgument : SubCommandArgumentHandlerBase<ConnectCommandBuilder>
{
    public string Name => "-m";

    private const string Default = "local";

    private readonly IFileSystemModeChecker _modeDefiner;

    public ModeArgument(IFileSystemModeChecker modeDefiner)
    {
        _modeDefiner = modeDefiner;
    }

    public override ConnectCommandBuilder Handle(IEnumerator<string> iterator, ConnectCommandBuilder builder)
    {
        if (iterator.Current != Name)
            return Next is null ? builder : Next.Handle(iterator, builder);

        if (!iterator.MoveNext())
            return builder;

        IFileSystemMode? mode = _modeDefiner.Apply(iterator.Current);
        if (mode is not null)
            return builder.UpdateFileSystemMode(mode);
        mode = _modeDefiner.Apply(Default);

        if (mode is not null)
            builder.UpdateFileSystemMode(mode);
        if (iterator.MoveNext() && Next is not null) return Next.Handle(iterator, builder);

        return builder;
    }
}