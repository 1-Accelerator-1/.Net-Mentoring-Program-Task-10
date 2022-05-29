using CustomBinarySerialization.Services.Interfaces;
using Models;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace CustomBinarySerialization.Services
{
    internal class JsonSerializationService : IJsonSerializationService
    {
        public async Task<Department> Deserialize(string fileName)
        {
            using (var fileStream = new FileStream(fileName, FileMode.Open))
            {
                var department = await JsonSerializer.DeserializeAsync<Department>(fileStream);

                return department;
            }
        }

        public async Task Serialize(string fileName, Department department)
        {
            using (var fileStream = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                await JsonSerializer.SerializeAsync(fileStream, department);
            }
        }
    }
}
