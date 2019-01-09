using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WcuStudentApi.Models
{
    public class Student
    {
        public ObjectId Id { get; set; }
        
        [BsonElement("Name")]
        public string StudentName { get; set; }

        [BsonElement("Major")]
        public string StudentMajor { get; set;}
        
    }
}