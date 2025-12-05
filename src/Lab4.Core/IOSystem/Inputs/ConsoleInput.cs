namespace Itmo.ObjectOrientedProgramming.Lab4.Core.IOSystem.Inputs;

public class ConsoleInput : IInput
{
    public string? ReadLine()
    {
        return Console.ReadLine();
    }
}