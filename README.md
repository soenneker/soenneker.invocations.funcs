[![](https://img.shields.io/nuget/v/soenneker.invocations.funcs.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.invocations.funcs/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.invocations.funcs/build-and-test.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.invocations.funcs/actions/workflows/build-and-test.yml)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.invocations.funcs/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.invocations.funcs/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.invocations.funcs.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.invocations.funcs/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.invocations.funcs/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.invocations.funcs/actions/workflows/codeql.yml)

# Soenneker.Invocations.Funcs

Represents a deferred synchronous function with explicit state, allowing a static delegate to avoid closure allocation.

## Install

```bash
dotnet add package Soenneker.Invocations.Funcs
```

## Usage

```csharp
using Soenneker.Invocations.Funcs;

var query = new PriceQuery(productId);

var invocation = new FuncInvocation<decimal>(
    static state => ((PriceQuery)state!).ReadPrice(),
    query);

pending.Enqueue(invocation);

// Later:
FuncInvocation<decimal> next = pending.Dequeue();
decimal price = next.Invoke();
```

`Invoke()` passes the stored `State` to the function and returns its result. It executes synchronously, propagates exceptions unchanged, and calls the function again on every invocation.

Use a `static` lambda or static method when avoiding closure capture matters. A capturing lambda remains valid but creates its own closure. Value-type state is boxed because state is stored as `object`.
