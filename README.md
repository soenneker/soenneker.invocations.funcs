[![](https://img.shields.io/nuget/v/soenneker.invocations.funcs.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.invocations.funcs/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.invocations.funcs/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.invocations.funcs/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.invocations.funcs.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.invocations.funcs/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.invocations.funcs/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.invocations.funcs/actions/workflows/codeql.yml)

# Soenneker.Invocations.Funcs

Deferred, stateful synchronous function invocation without closure capture.

## Install

```bash
dotnet add package Soenneker.Invocations.Funcs
```

## What you get

- `FuncInvocation<T>` — Deferred, stateful synchronous function invocation without closure capture.

## API at a glance

| API | What it does | Result / important behavior |
| --- | --- | --- |
| `FuncInvocation<T>.State` | Gets state. | Gets state. |
| `FuncInvocation<T>.Invoke()` | Executes the invoke operation. | The result of the operation. |
