using System;
using System.Text;

namespace TextUtils
{
    public sealed class TextConverter
    {
        private static readonly string[] NumPad =
            {
                "0", "2", "22", "222",
                "3", "33", "333",
                "4", "44", "444",
                "5", "55", "555",
                "6", "66", "666",
                "7", "77", "777", "7777",
                "8", "88", "888",
                "9", "99", "999", "9999"
            };

        /// <summary>
        /// Converts an input non-null string into the sequence of keypresses.
        /// </summary>
        /// <param name="input">Input string.</param>
        /// <returns>Sequence of keypresses</returns>
        public string Convert(string input)
        {
            Guard.ArgumentNotNullOrEmpty(input, nameof(input));

            var lastKey = -1;
            var result = new StringBuilder(input.Length * 2);

            foreach (var c in input)
            {
                var index = Math.Max(c - 'a' + 1, 0);
                var currentKey = (int)char.GetNumericValue(NumPad[index][0]);

                if (lastKey == Math.Max(currentKey, 0))
                {
                    result.Append(" ");
                }

                lastKey = currentKey;

                result.Append(NumPad[index]);
            }

            return result.ToString();
        }
    }
}