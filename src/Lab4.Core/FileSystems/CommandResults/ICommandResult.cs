using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.CommandResults.Visitors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.CommandResults;

public interface ICommandResult
{
    void Accept(ICommandResultVisitor visitor);
}