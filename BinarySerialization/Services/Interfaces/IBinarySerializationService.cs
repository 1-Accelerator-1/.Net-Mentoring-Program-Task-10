using Models;

namespace CustomBinarySerialization.Services.Interfaces
{
    public interface IBinarySerializationService
    {
        public void Serialize(string fileName, Department department);

        public Department Deserialize(string fileName);
    }
}
