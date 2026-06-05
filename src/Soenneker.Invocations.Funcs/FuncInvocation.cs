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
    /// Gets state.
    /// </summary>
    public object? State { get; }

    public FuncInvocation(Func<object?, T> func, object? state)
    {
        _func = func ?? throw new ArgumentNullException(nameof(func));
        State = state;
    }

    /// <summary>
    /// Executes the invoke operation.
    /// </summary>
    /// <returns>The result of the operation.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public T Invoke() => _func(State);
}