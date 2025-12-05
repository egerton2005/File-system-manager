namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandBuilders;

public interface ICommandBuilder
{
    ICommand? Build();
}