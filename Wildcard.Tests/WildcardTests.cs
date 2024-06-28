using System.Text.RegularExpressions;

namespace Asjc.Wildcard.Tests
{
    [TestClass]
    public class WildcardTests
    {
        [TestMethod]
        public void Wildcard1() => Assert.IsTrue(((Regex)new Wildcard("a*b?c")).ToString() == "^a.*b.c$");

        [TestMethod]
        public void Wildcard2() => Assert.IsTrue(new Wildcard("a*c").IsMatch("abbc"));

        [TestMethod]
        public void Wildcard3() => Assert.IsTrue(new Wildcard("a*c").IsMatch("ac"));

        [TestMethod]
        public void Wildcard4() => Assert.IsFalse(new Wildcard("a*c").IsMatch("abcd"));

        [TestMethod]
        public void Wildcard5() => Assert.IsTrue(new Wildcard("a?c").IsMatch("abc"));


        [TestMethod]
        public void Wildcard6() => Assert.IsFalse(new Wildcard("a?c").IsMatch("abbc"));

        [TestMethod]
        public void Wildcard7() => Assert.IsFalse(new Wildcard(@"a\*c").IsMatch("abc"));

        [TestMethod]
        public void Wildcard8() => Assert.IsTrue(new Wildcard(@"a\*c").IsMatch("a*c"));

        [TestMethod]
        public void Wildcard9() => Assert.IsTrue(new Wildcard(@"Does * work\?").IsMatch("Does it work?"));


        [TestMethod]
        public void Wildcard10() => Assert.IsTrue(Wildcard.IsMatch("Does it work?", @"Does * work\?"));
    }
}