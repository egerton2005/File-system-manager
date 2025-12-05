using Itmo.ObjectOrientedProgramming.Lab4.Core.IOSystem.Outputs;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.CommandResults.ResultVisitors;

public class OutputCommandResultVisitor : ICommandResultVisitor
{
    private readonly IOutput _output;

    public OutputCommandResultVisitor(IOutput output)
    {
        _output = output;
    }

    public void Accept(FailureResult result)
    {
        _output.WriteLine(result.Error.Message);
    }

    public void Accept(SuccessVoidResult result)
    {
        // nothing
    }

    public void Accept(SuccessTreeResult result)
    {
        // result.Node.Accept(depth);
    }
}