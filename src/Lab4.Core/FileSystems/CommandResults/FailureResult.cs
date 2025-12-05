using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.CommandResults.ResultVisitors;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.Errors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.CommandResults;

public class FailureResult : ICommandResult
{
    public IFileSystemError Error { get; }

    public FailureResult(IFileSystemError error)
    {
        Error = error;
    }

    public void Accept(ICommandResultVisitor visitor) => visitor.Accept(this);
}