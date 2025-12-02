namespace Itmo.ObjectOrientedProgramming.Lab4.Core.IOSystem.FileShowModes;

public class ConsoleFileShowMode : IFileShowMode
{
    public string Name => "console";

    public void PrintFile(Stream fileStream)
    {
        var reader = new StreamReader(fileStream);
        string content = reader.ReadToEnd();
        Console.WriteLine(content);
    }
}