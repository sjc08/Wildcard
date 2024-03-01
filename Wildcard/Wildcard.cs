using System.Text.RegularExpressions;

namespace Asjc.Wildcard
{
    public class Wildcard
    {
        public Wildcard(string pattern) => Pattern = pattern;

        public string Pattern { get; }

        public bool IsMatch(string input)
            => IsMatch(input, Pattern);

        public static bool IsMatch(string input, string pattern)
            => Regex.IsMatch(input, ToRegex(pattern));

        public string ToRegex()
            => ToRegex(Pattern);

        public static string ToRegex(string pattern)
            => $"^{Regex.Escape(pattern).Replace("\\*", ".*").Replace("\\?", ".")}$";

        public override string ToString() => Pattern;
    }
}
