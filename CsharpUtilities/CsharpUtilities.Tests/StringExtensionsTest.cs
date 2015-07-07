using System;
using CsharpUtilities.Extensions;
using Xunit;

namespace CsharpUtilities.Tests
{
    public class StringExtensionsTest
    {
        [Fact]
        public void NullStringReturnsStringEmpty()
        {
            var expected = string.Empty;
            var actual = StringExtensions.ToFriendlyString(null);

            Assert.Equal<string>(expected, actual);
        }

        [Fact]
        public void DoubleDashesReturnsOneDash()
        {
            var actual = StringExtensions.ToFriendlyString("word1--word2");
            var expected = "word1-word2";

            Assert.Equal<string>(expected, actual);
        }

        [Fact]
        public void DoubleSpacesReturnsOneDash()
        {
            var actual = StringExtensions.ToFriendlyString("word1  word2");
            var expected = "word1-word2";

            Assert.Equal<string>(expected, actual);
        }

        [Fact]
        public void TrailingSpaceReturnsOneDash()
        {
            var actual = StringExtensions.ToFriendlyString(" word ");
            var expected = "-word-";

            Assert.Equal<string>(expected, actual);
        }   

        [Fact]
        public void TrailingSpacesReturnsOneDash()
        {
            var actual = StringExtensions.ToFriendlyString("   word  ");
            var expected = "-word-";

            Assert.Equal<string>(expected, actual);
        }   
    }
}
