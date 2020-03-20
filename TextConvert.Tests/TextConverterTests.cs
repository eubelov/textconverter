using System;

using TextUtils;

using Xunit;

namespace TextConvert.Tests
{
    public sealed class TextConverterTests
    {
        private readonly TextConverter textConverter;

        public TextConverterTests()
        {
            this.textConverter = new TextConverter();
        }

        [Fact]
        public void Throw_ArgumentNullException_When_Input_Is_Null()
        {
            Assert.Throws<ArgumentNullException>(() => this.textConverter.Convert(null));
        }

        [Fact]
        public void Throw_ArgumentNullException_When_Input_Is_Empty()
        {
            Assert.Throws<ArgumentNullException>(() => this.textConverter.Convert(string.Empty));
        }

        [Fact]
        public void Can_Convert_Single_Space()
        {
            var sequence = this.textConverter.Convert(" ");

            Assert.Equal("0", sequence);
        }

        [Fact]
        public void Can_Convert_Multiple_Sequential_Spaces()
        {
            var sequence = this.textConverter.Convert(" " + " " + " ");

            Assert.Equal("0 0 0", sequence);
        }

        [Fact]
        public void Can_Convert_Sequential_Characters()
        {
            var sequence = this.textConverter.Convert("aa");

            Assert.Equal("2 2", sequence);
        }

        [Theory]
        [InlineData(" a ", "020")]
        [InlineData(" abc ", "02 22 2220")]
        public void Can_Convert_Input_With_Space(string input, string expected)
        {
            var sequence = this.textConverter.Convert(input);

            Assert.Equal(expected, sequence);
        }

        [Theory]
        [InlineData("abc", 2)]
        [InlineData("def", 3)]
        [InlineData("ghi", 4)]
        [InlineData("jkl", 5)]
        [InlineData("mno", 6)]
        [InlineData("pqrs", 7)]
        [InlineData("tuv", 8)]
        [InlineData("wxyz", 9)]
        [InlineData(" ", 0)]
        public void Correct_Button_Is_Assigned(string input, int expectedIndex)
        {
            foreach (var c in input)
            {
                var sequence = this.textConverter.Convert(c.ToString());

                Assert.Equal(expectedIndex, int.Parse(sequence[0].ToString()));
            }
        }
    }
}
