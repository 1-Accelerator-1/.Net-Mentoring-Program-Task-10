using CustomBinarySerialization.Models;

namespace CustomBinarySerialization.Services.Interfaces
{
    public interface IBinarySerializationService
    {
        public void Serialize(string fileName, Person person);

        public Person Deserialize(string fileName);
    }
}
