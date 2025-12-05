using System.Text;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.ArgumentParsers;

public class DefaultArgumentParser : IArgumentParser
{
    public IEnumerable<string> Parse(string input)
    {
        var arguments = new List<string>();
        IEnumerable<string> lines = input.Split('\n');
        foreach (string line in lines)
            arguments.AddRange(ExecuteLine(line));

        return arguments;
    }

    private static List<string> ExecuteLine(string line)
    {
        var result = new List<string>();
        var current = new StringBuilder();
        bool inQuotes = false;

        foreach (char c in line)
        {
            if (c == '"')
            {
                inQuotes = !inQuotes;
            }
            else if (c == ' ' && !inQuotes)
            {
                if (current.Length > 0)
                {
                    result.Add(current.ToString());
                    current.Clear();
                }
            }
            else
            {
                current.Append(c);
            }
        }

        if (current.Length > 0)
            result.Add(current.ToString());

        return result;
    }
}