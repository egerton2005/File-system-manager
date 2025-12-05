namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandBuilders;

public class TreeListCommandBuilder : ICommandBuilder
{
    private int? _depth;

    public TreeListCommandBuilder WithDepth(int depth)
    {
        _depth = depth;
        return this;
    }

    public ICommand? Build()
    {
        if (_depth is null)
            return null;

        return new TreeListCommand(_depth.Value);
    }
}