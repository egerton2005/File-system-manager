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
        var remainingArguments = new List<string>();
        do
        {
            if (iterator.Current != Name)
            {
                remainingArguments.Add(iterator.Current);
                continue;
            }

            if (!iterator.MoveNext())
                return Next is null ? builder : Next.Handle(remainingArguments.GetEnumerator(), builder);

            IFileSystemMode? mode = _modeDefiner.Apply(iterator.Current);
            if (mode is not null)
                builder.UpdateFileSystemMode(mode);
            mode = _modeDefiner.Apply(Default);

            if (mode is not null)
                builder.UpdateFileSystemMode(mode);
        }
        while (iterator.MoveNext());

        return Next is null ? builder : Next.Handle(remainingArguments.GetEnumerator(), builder);
    }
}