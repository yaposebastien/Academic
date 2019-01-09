//This class service add CRUD Operations to our application
using System.Collections.Generic;
using System.Linq;
using WcuStudentApi.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;

namespace WcuStudentApi.Services
{
    public class StudentService
    {
        private readonly IMongoCollection<Student> _students;

        public StudentService(IConfiguration config)
        {
            //Ces variables permettent de lire la configuration de notre BD, access a la BD, lire la collection creee
            var client = new MongoClient(config.GetConnectionString("WcuStudentApiDb"));
            var database = client.GetDatabase("WcuStudentApiDb");
            _students = database.GetCollection<Student>("Students");
        }

        public List<Student> Get()
        {
            return _students.Find(Student => true).ToList();
        }

        public Student Get(string id)
        {
            var docId = new ObjectId(id);
            return _students.Find<Student>(student => student.Id == docId).FirstOrDefault();
        }

        public Student Create(Student student)
        {
            _students.InsertOne(student);
            return student;
        }

        public void Update(string id, Student studentIn)
        {
            var docId = new ObjectId(id);
            _students.ReplaceOne(student => student.Id == docId, studentIn);
        }

        public void Remove(Student studentIn)
        {
            _students.DeleteOne(student => student.Id == studentIn.Id);
        }

        public void Remove(ObjectId id)
        {
            _students.DeleteOne(student => student.Id == id);
        }
    }
}
