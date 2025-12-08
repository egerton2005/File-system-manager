namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.CommandResults;

public class IncorrectedPathError : IFileSystemError
{
    public string Message => "Incorrected path error";
}