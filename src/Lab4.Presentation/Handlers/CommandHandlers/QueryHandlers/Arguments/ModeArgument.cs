using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Core.IOSystem.FileSystemModes;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Handlers.Arguments;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Handlers.CommandHandlers.QueryHandlers.Arguments.ResponsibilityChainMods.FilleSystemModes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Handlers.CommandHandlers.QueryHandlers.Arguments;

public class ModeArgument : IFlagArgument<ConnectCommandBuilder>
{
    public string Name => "-m";

    private const string Default = "local";

    private readonly IFileSystemModeChecker _modeDefiner;

    public ModeArgument(IFileSystemModeChecker modeDefiner)
    {
        _modeDefiner = modeDefiner;
    }

    public ConnectCommandBuilder Handle(IEnumerator<string> arguments, ConnectCommandBuilder builder)
    {
        if (arguments.MoveNext())
        {
            IFileSystemMode? mode = _modeDefiner.Apply(arguments.Current);
            if (mode is not null)
                return builder.UpdateFileSystemMode(mode);
            mode = _modeDefiner.Apply(Default);
            return mode is not null ? builder.UpdateFileSystemMode(mode) : builder;
        }

        return builder;
    }
}