using Models;

namespace CustomBinarySerialization.Services.Interfaces
{
    public interface IXmlSerializationService
    {
        public void Serialize(string fileName, Department department);

        public Department Deserialize(string fileName);
    }
}
