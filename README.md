[![NuGet](https://img.shields.io/nuget/v/Asjc.Wildcard)](https://www.nuget.org/packages/Asjc.Wildcard/)

A very simple package that implements **wildcard** matching. Don't expect it to be fast, because its essential operation is to convert to `regex`. Therefore, its only purpose is to simplify the input, not replace the regex.

## Quick Start

```c#
bool match = new Wildcard("Does * work\\?").IsMatch("Does it work?"); // True
```

