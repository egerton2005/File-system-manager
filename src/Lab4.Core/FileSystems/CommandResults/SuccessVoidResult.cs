using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.CommandResults.ResultVisitors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.CommandResults;

public class SuccessVoidResult : ICommandResult
{
    public SuccessVoidResult() { }

    public void Accept(ICommandResultVisitor visitor) => visitor.Accept(this);
}