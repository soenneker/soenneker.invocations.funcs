using System.Threading.Tasks;
using Soenneker.Tests.Unit;

namespace Soenneker.Invocations.Funcs.Tests;

public sealed class FuncInvocationTests : UnitTest
{
    [Test]
    public void Default()
    {

    }

    [Test]
    public async Task Invoke_returns_result_from_explicit_state()
    {
        var input = new Calculation(21);
        var invocation = new FuncInvocation<int>(static state => ((Calculation)state!).Input * 2, input);

        int result = invocation.Invoke();

        await Assert.That(result).IsEqualTo(42);
        await Assert.That(invocation.State).IsSameReferenceAs(input);
    }

    private sealed class Calculation(int input)
    {
        public int Input { get; } = input;
    }
}
