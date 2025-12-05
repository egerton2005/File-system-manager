using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Handlers.Arguments;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Handlers.CommandHandlers.QueryHandlers.Arguments;

public class CopySourcePathArgument : IPositionalArgument<FileCopyCommandBuilder>
{
    public FileCopyCommandBuilder Handle(IEnumerator<string> arguments, FileCopyCommandBuilder builder)
        => builder.WithSource(arguments.Current);
}