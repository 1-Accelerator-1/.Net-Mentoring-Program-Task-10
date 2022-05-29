using CustomBinarySerialization.Services.Interfaces;
using Models;
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

        public Department Deserialize(string fileName)
        {
            using (var fileStream = new FileStream(fileName, FileMode.Open))
            {
                var department = (Department)_binaryFormatter.Deserialize(fileStream);

                return department;
            }
        }

        public void Serialize(string fileName, Department department)
        {
            using (var fileStream = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                _binaryFormatter.Serialize(fileStream, department);
            }
        }
    }
}
