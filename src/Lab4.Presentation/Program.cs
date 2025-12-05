using Itmo.ObjectOrientedProgramming.Lab4.Core.ConnectionContexts;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.CommandResults;
using Itmo.ObjectOrientedProgramming.Lab4.Core.SystemPathUtilities;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Handlers.CommandHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Handlers.CommandHandlers.QueryHandlers.Factories;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.ArgumentParsers;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.Results;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation;

public class Program
{
    private static void Main()
    {
        INameCommand handler = new DefaultSystemFactory().Create();
        var parser = new DefaultCommandParser(handler);
        var argumentParser = new DefaultArgumentParser();

        Console.WriteLine("Enter commands:");

        IPathUtility utility = new WindowsPathUtility();
        IFileSystemContext context = new FileSystemContext(utility);

        while (true)
        {
            string? input = Console.ReadLine();

            if (input == "exit") break;
            if (string.IsNullOrEmpty(input)) continue;

            CommandParsingResult result = parser.Parse(argumentParser.Parse(input));

            if (result is CommandParsingResult.Success success)
            {
                if (success.Command.Execute(context) is CommandResult.Failure failure)
                    Console.WriteLine(failure.Error.Message);
                else
                    Console.WriteLine("Success");
            }
            else if (result is CommandParsingResult.Failure failure)
            {
                Console.WriteLine(failure.Error.Message);
            }
        }
    }
}