using CustomBinarySerialization.Models;
using CustomBinarySerialization.Services.Interfaces;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace CustomBinarySerialization.Services
{
    public class BinarySerializationService : IBinarySerializationService
    {
        private BinaryFormatter _binaryFormatter;

        public BinarySerializationService()
        {
            _binaryFormatter = new BinaryFormatter();
        }

        public Person Deserialize(string fileName)
        {
            using (var fileStream = new FileStream(fileName, FileMode.Open))
            {
                var department = (Person)_binaryFormatter.Deserialize(fileStream);

                return department;
            }
        }

        public void Serialize(string fileName, Person person)
        {
            using (var fileStream = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                _binaryFormatter.Serialize(fileStream, person);
            }
        }
    }
}
