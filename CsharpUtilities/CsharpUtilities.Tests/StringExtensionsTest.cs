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

        [Fact]
        public void PascalCaseReturnsLowercase()
        {
            var expected = "pascalcase-title";
            var actual = StringExtensions.ToFriendlyString("PascalCase Title");

            Assert.Equal<string>(expected, actual);
        }

        [Fact]
        public void LowercaseReturnsLowercase()
        {
            var expected = "lowercase-title";
            var actual = StringExtensions.ToFriendlyString("lowercase title");

            Assert.Equal<string>(expected, actual);
        }

        [Fact]
        public void UppercaseReturnsLowercase()
        {
            var expected = "uppercase-title";
            var actual = StringExtensions.ToFriendlyString("UPPERCASE TITLE");

            Assert.Equal<string>(expected, actual);
        }

        [Fact]
        public void UnderscoreIsRemoved()
        {
            var expected = "modulename";
            var actual = StringExtensions.ToFriendlyString("module_name");

            Assert.Equal<string>(expected, actual);
        }

        [Fact]
        public void ToFriendlyStringIsAnExtensionMethod()
        {
            var text = "Test Title";
            var expected = "test-title";
            var actual = text.ToFriendlyString();

            Assert.Equal<string>(expected, actual);
        }
    }
}
