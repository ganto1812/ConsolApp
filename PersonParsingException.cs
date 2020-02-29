using System;

namespace ConsoleAppText
{
    internal class PersonParsingException : Exception
    {
        public string Line { get; private set; }

        public PersonParsingException(string message, string line) : base(message)
        {
            Line = line;
        }

        public PersonParsingException(string message, Exception innerException, string line) : base(message, innerException)
        {
            Line = line;
        }
    }
}
