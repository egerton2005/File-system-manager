namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Handlers.Arguments;

public interface IPositionalArgument<TBuilder>
{
    TBuilder Handle(IEnumerator<string> arguments, TBuilder builder);
}