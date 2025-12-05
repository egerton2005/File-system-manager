namespace Itmo.ObjectOrientedProgramming.Lab4.Core.IOSystem.FileShowModes.Factory;

public interface IFileShowModeFactory
{
    string Name { get; }

    IFileShowMode Create();
}