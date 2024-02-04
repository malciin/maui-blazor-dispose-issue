namespace ServiceDisposalBlazorIssue;

internal class SingletonServiceThatRequiresDispose : IDisposable
{
    public void Dispose()
    {
        Console.WriteLine("I am never called!");
    }
}
