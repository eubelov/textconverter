using System;
using System.Collections.Generic;
using System.Linq;

using TextUtils;

namespace TextConverter.Runner
{
    public sealed class Program
    {
        public static void Main()
        {
            if (!int.TryParse(Console.ReadLine(), out var totalInputString))
            {
                Console.WriteLine("Input is not numeric, exiting.");
                return;
            }

            if (totalInputString < 1 || totalInputString > 100)
            {
                Console.WriteLine("Number of cases must be between 1 and 100");
                return;
            }

            var input = new string[totalInputString];

            for (var i = 0; i < totalInputString; i++)
            {
                var line = Console.ReadLine();

                Guard.ArgumentNotNullOrEmpty(line, "input");

                // ReSharper disable once PossibleNullReferenceException
                if (line.Length > 1000)
                {
                    Console.WriteLine("Input mustn't be longer than 1000 characters.");
                    return;
                }

                // Assuming input contains only lowercase letters. Otherwise one more check is required.
                input[i] = line;
            }

            ProcessInput(input);
        }

        private static void ProcessInput(IEnumerable<string> input)
        {
            var textConverter = new TextUtils.TextConverter();

            foreach (var result in input.Select((s, i) => $"Case #{i+1}: {textConverter.Convert(s)}"))
            {
                Console.WriteLine(result);
            }
        }
    }
}
