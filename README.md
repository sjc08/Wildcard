[![NuGet](https://img.shields.io/nuget/v/Asjc.Wildcard)](https://www.nuget.org/packages/Asjc.Wildcard/)

A very simple package that implements **wildcard** matching. Don't expect it to be fast, because its essential operation is to convert to `regex`. Therefore, its only purpose is to simplify the input, not replace the regex.

## Quick Start

```c#
new Wildcard(@"Does * work\?").IsMatch("Does it work?");
```

In this example, the `IsMatch` method returns `True`.

- The `*` wildcard matches the `it` part.
- The escape character `\` is used to indicate that the following `?` character should be matched as a literal character, not as a wildcard.

## More information

From https://www.computerhope.com/jargon/w/wildcard.htm:

### Asterisk ( * ) in a wildcard

The asterisk in a wildcard matches any character zero or more times. For example, "comp*" matches anything beginning with "comp," which means "comp," "complete," and "computer" are all matched.

### Question mark ( ? ) in a wildcard

A question mark matches a single character once. For example, "c?mp" matches "camp" and "comp." The question mark can also be used more than once. For example, "c??p" would match the above examples. In MS-DOS and the Windows command line, the question mark can also match any trailing question mark zero or one time. For example, "co??" would match all of the above matches, but because they are trailing question marks, it would also match "cop" even though it's not four characters.
