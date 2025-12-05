using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.CommandResults.ResultVisitors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.CommandResults;

public interface ICommandResult
{
    void Accept(ICommandResultVisitor visitor);
}