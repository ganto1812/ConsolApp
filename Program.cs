using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleAppText
{
    public class Program
    {
        private static void Main()
        {
            const string filePath = @"text.txt";

            List<string> lines = ReadLinesFromFile(filePath);

            var people = PopulatePeople(lines);
            PrintPeople(people);

            var newPerson = CreateNewPerson();
            people.Add(newPerson);

            SavePeopleToFile(people, filePath);

            var linesAfterSave = ReadLinesFromFile(filePath);
            foreach (var line in linesAfterSave)
            {
                Console.WriteLine(line);
            }
        }

        private static void SavePeopleToFile(List<Person> people, string filePath)
        {
            var lines = people.Select((person) => person.ToCommaFormat());
            File.WriteAllLines(filePath, lines);
        }

        private static Person CreateNewPerson()
        {
            Console.Write("First name: ");
            var newEntryName = Console.ReadLine();
            Console.Write("Action: ");
            var newEntryAction = Console.ReadLine();
            Console.Write("Message: ");
            var newEntryMessage = Console.ReadLine();
            Console.WriteLine();

            return new Person()
            {
                FirstName = newEntryName,
                Action = newEntryAction,
                Message = newEntryMessage
            };
        }

        private static void PrintPeople(List<Person> people)
        {
            foreach (var person in people)
            {
                Console.WriteLine(person);
            }
        }

        private static List<Person> PopulatePeople(List<string> lines)
        {
            var people = new List<Person>();
            foreach (var line in lines)
            {
                try
                {
                    var person = Person.FromString(line);
                    people.Add(person);
                }
                catch (PersonParsingException ex)
                {
                    Console.WriteLine($"Malformed line: {ex.Line}");
                    Console.WriteLine($"Exception: {ex.Message}");
                }
            }
            return people;
        }

        private static List<string> ReadLinesFromFile(string filePath)
        {
            return File
                .ReadAllLines(filePath)
                .Where(line => !string.IsNullOrWhiteSpace(line))
                .ToList();
        }
    }
}