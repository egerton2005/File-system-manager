namespace Itmo.ObjectOrientedProgramming.Lab4.Core.IOSystem.Outputs;

public class ConsoleOutput : IOutput
{
    public void WriteLine(string? value)
    {
        Console.WriteLine(value);
    }
}