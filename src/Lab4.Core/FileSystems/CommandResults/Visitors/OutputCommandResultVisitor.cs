using Itmo.ObjectOrientedProgramming.Lab4.Core.IOSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.CommandResults.Visitors;

public class OutputCommandResultVisitor : ICommandResultVisitor
{
    private readonly IOutput _output;

    public OutputCommandResultVisitor(IOutput output)
    {
        _output = output;
    }

    public void Accept(FailureResult result)
    {
        _output.WriteLine(result.Message);
    }

    public void Accept(SuccessVoidResult result)
    {
        // nothing
    }
}