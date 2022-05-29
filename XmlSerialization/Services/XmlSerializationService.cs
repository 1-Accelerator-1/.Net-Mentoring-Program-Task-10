using CustomBinarySerialization.Services.Interfaces;
using Models;
using System.IO;
using System.Xml.Serialization;

namespace CustomBinarySerialization.Services
{
    internal class XmlSerializationService : IXmlSerializationService
    {
        private XmlSerializer _xmlSerializer;

        public XmlSerializationService()
        {
            _xmlSerializer = new XmlSerializer(typeof(Department));
        }

        public Department Deserialize(string fileName)
        {
            using (var fileStream = new FileStream(fileName, FileMode.Open))
            {
                var department = (Department)_xmlSerializer.Deserialize(fileStream);

                return department;
            }
        }

        public void Serialize(string fileName, Department department)
        {
            using (var fileStream = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                _xmlSerializer.Serialize(fileStream, department);
            }
        }
    }
}
