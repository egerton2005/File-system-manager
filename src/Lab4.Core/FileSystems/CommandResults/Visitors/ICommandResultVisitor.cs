namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.CommandResults.Visitors;

public interface ICommandResultVisitor
{
    void Accept(FailureResult result);

    void Accept(SuccessVoidResult result);
}