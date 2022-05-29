using CustomBinarySerialization.Models;
using CustomBinarySerialization.Services;
using System;

namespace CustomBinarySerialization
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var person = new Person(1, "Name 1");

            var binarySerializationService = new BinarySerializationService();

            try
            {
                binarySerializationService.Serialize("person.dat", person);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Serialization failed.");
                Console.WriteLine(ex.Message);
                return;
            }

            Person newPerson;
            try
            {
                newPerson = binarySerializationService.Deserialize("person.dat");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Deserialization failed.");
                Console.WriteLine(ex.Message);
                return;
            }

            Console.WriteLine("Person: ");
            Console.WriteLine($"Id: {newPerson.Id}");
            Console.WriteLine($"Name: {newPerson.Name}");
        }
    }
}
