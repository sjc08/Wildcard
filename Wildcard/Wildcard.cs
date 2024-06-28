using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Asjc.Wildcard
{
    public class Wildcard : Regex
    {
        private new readonly string pattern;

        public Wildcard(string pattern) : base(ToRegex(pattern)) => this.pattern = pattern;

        public Wildcard(string pattern, RegexOptions options) : base(ToRegex(pattern), options) => this.pattern = pattern;

        public Wildcard(string pattern, RegexOptions options, TimeSpan matchTimeout) : base(ToRegex(pattern), options, matchTimeout) => this.pattern = pattern;

        public static string ToRegex(string pattern)
        {
            var sb = new StringBuilder();
            bool escaping = false;
            sb.Append("^");
            foreach (var c in pattern)
            {
                if (escaping)
                {
                    sb.Append(Escape(c.ToString()));
                    escaping = false;
                }
                else
                {
                    switch (c)
                    {
                        case '\\':
                            escaping = true;
                            break;
                        case '*':
                            sb.Append(".*");
                            break;
                        case '?':
                            sb.Append(".");
                            break;
                        default:
                            sb.Append(Escape(c.ToString()));
                            break;
                    }
                }
            }
            sb.Append("$");
            return sb.ToString();
        }

        public static new bool IsMatch(string input, string pattern) => Regex.IsMatch(input, ToRegex(pattern));

        public static new bool IsMatch(string input, string pattern, RegexOptions options) => Regex.IsMatch(input, ToRegex(pattern), options);

        public static new bool IsMatch(string input, string pattern, RegexOptions options, TimeSpan matchTimeout) => Regex.IsMatch(input, ToRegex(pattern), options, matchTimeout);

        public new string ToString() => pattern;
    }
}
