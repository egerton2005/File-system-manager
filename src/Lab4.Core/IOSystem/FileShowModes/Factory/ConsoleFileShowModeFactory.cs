namespace Itmo.ObjectOrientedProgramming.Lab4.Core.IOSystem.FileShowModes.Factory;

public class ConsoleFileShowModeFactory : IFileShowModeFactory
{
    public string Name => "console";

    public IFileShowMode Create()
        => new ConsoleFileShowMode();
}