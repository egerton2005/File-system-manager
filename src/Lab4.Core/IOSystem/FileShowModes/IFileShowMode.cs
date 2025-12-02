namespace Itmo.ObjectOrientedProgramming.Lab4.Core.IOSystem.FileShowModes;

public interface IFileShowMode
{
    string Name { get; }

    void PrintFile(Stream fileStream);
}