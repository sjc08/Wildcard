using System.Text;
using System.Text.RegularExpressions;

namespace Asjc.Wildcard
{
    public class Wildcard
    {
        public Wildcard(string pattern)
        {
            Pattern = pattern;
            EquivalentRegex = ToRegex(pattern);
        }

        public string Pattern { get; }
        public string EquivalentRegex { get; }

        public bool IsMatch(string input)
            => Regex.IsMatch(input, EquivalentRegex);

        public static bool IsMatch(string input, string pattern)
            => new Wildcard(pattern).IsMatch(input);

        public static string ToRegex(string pattern)
        {
            var sb = new StringBuilder();
            bool escaping = false;

            sb.Append("^");

            foreach (var c in pattern)
            {
                if (escaping)
                {
                    sb.Append(Regex.Escape(c.ToString()));
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
                            sb.Append(Regex.Escape(c.ToString()));
                            break;
                    }
                }
            }

            sb.Append("$");

            return sb.ToString();
        }

        public override string ToString() => Pattern;
    }
}
