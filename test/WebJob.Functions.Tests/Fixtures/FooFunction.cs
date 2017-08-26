namespace WebJob.Functions.Tests.Fixtures
{
    /// <summary>
    /// This provides interfaces to the <see cref="FooFunction"/> class.
    /// </summary>
    public interface IFooFunction
    {
    }

    /// <summary>
    /// This represents the Foo function entity.
    /// </summary>
    public class FooFunction : FunctionBase, IFooFunction
    {
    }
}
