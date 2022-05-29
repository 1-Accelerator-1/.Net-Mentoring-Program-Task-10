using System;
using System.Runtime.Serialization;

namespace CustomBinarySerialization.Models
{
    [Serializable]
    public class Person : ISerializable
    {
        public Person(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public Person(SerializationInfo info, StreamingContext ctxt)
        {
            Id = (int)info.GetValue("PersonId", typeof(int));
            Name = (string)info.GetValue("PersonName", typeof(string));
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("PersonId", Id);
            info.AddValue("PersonName", Name);
        }
    }
}
