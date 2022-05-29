using Models;
using System.Threading.Tasks;

namespace CustomBinarySerialization.Services.Interfaces
{
    public interface IJsonSerializationService
    {
        public Task Serialize(string fileName, Department department);

        public Task<Department> Deserialize(string fileName);
    }
}
