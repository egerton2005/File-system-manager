namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Handlers.Arguments;

public interface IFlagArgument<TBuilder>
{
    string Name { get; }

    TBuilder Handle(IEnumerator<string> arguments, TBuilder builder);
}