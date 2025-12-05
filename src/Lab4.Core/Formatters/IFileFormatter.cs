namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Formatters;

public interface IFileFormatter
{
    string FormatDirectory(string name, int depth);

    string FormatFile(string name, int depth);
}