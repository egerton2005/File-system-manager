using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.CommandResults.Visitors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.CommandResults;

public class FailureResult : ICommandResult
{
    public string Message { get; }

    public FailureResult(string error)
    {
        Message = error;
    }

    public void Accept(ICommandResultVisitor visitor) => visitor.Accept(this);
}