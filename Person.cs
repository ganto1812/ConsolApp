using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppText
{
    public class Person
    {
        public string FirstName { get; set; }
        public string Action { get; set; }
        public string Message { get; set; }

        public override string ToString() => $"{FirstName}, Action: {Action}. Note: {Message}.";

        /// <summary>
        /// Tries to convert a line of text into a <see cref="Person" />
        /// </summary>
        /// <param name="line">The string to be parsed</param>
        /// <returns>A person</returns>
        /// <exception>Throws a <see cref="PersonParsingException" /> if parsing failed.</exception>
        public static Person FromString(string line)
        {
            try
            {
                var entries = line.Split(',');
                return new Person
                {
                    FirstName = entries[0],
                    Action = entries[1],
                    Message = entries[2]
                };
            }
            catch (IndexOutOfRangeException ex)
            {
                throw new PersonParsingException("Unable to parse person from line in text file.", ex, line);
            }
        }

        public string ToCommaFormat() => $"{FirstName},{Action},{Message}";
    }
}
