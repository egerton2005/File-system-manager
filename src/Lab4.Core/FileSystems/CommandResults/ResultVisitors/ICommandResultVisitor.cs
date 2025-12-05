namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.CommandResults.ResultVisitors;

public interface ICommandResultVisitor
{
    void Accept(FailureResult result);

    void Accept(SuccessVoidResult result);

    void Accept(SuccessTreeResult result);
}