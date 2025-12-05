namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandBuilders;

public class DisconnectCommandBuilder : ICommandBuilder
{
    public ICommand? Build()
    {
        return new DisconnectCommand();
    }
}