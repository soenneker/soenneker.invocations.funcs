using System;
using System.Runtime.CompilerServices;

namespace Soenneker.Invocations.Funcs;

/// <summary>
/// Deferred, stateful synchronous function invocation without closure capture.
/// </summary>
public sealed class FuncInvocation<T>
{
    private readonly Func<object?, T> _func;

    /// <summary>
    /// Gets the state passed to the function when <see cref="Invoke"/> is called.
    /// </summary>
    public object? State { get; }

    /// <summary>
    /// Creates a deferred function invocation from a function and its explicit state.
    /// </summary>
    /// <param name="func">The function to invoke.</param>
    /// <param name="state">The state supplied to <paramref name="func"/>.</param>
    public FuncInvocation(Func<object?, T> func, object? state)
    {
        _func = func ?? throw new ArgumentNullException(nameof(func));
        State = state;
    }

    /// <summary>
    /// Invokes the function with <see cref="State"/>.
    /// </summary>
    /// <returns>The value returned by the function.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public T Invoke() => _func(State);
}
