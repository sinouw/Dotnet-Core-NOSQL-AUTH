using MongoDB.Bson;
using MongoDB.Driver;
using MyAwesomeWebApi.Models.Papras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAwesomeWebApi.Services
{
    public class ClassroomService
    {

        //----------------------------------------------------
        //----------------------------------------------------
        //----------------------------------------------------
        public IMongoCollection<Classroom> ClassroomCollection { get; }

        public ClassroomService(string databaseName, string collectionName, string databaseUrl)
        {
            var mongoClient = new MongoClient(databaseUrl);
            var mongoDataBase = mongoClient.GetDatabase(databaseName);
            ClassroomCollection = mongoDataBase.GetCollection<Classroom>(collectionName);
        }

        //----------------------------------------------------
        //-----------------GetAllclassrooms-------------------
        //----------------------------------------------------
        public async Task<List<Classroom>> GetAllclassrooms()
        {
            var classrooms = new List<Classroom>();

            var allDocuments = await ClassroomCollection.FindAsync(new BsonDocument());

            await allDocuments.ForEachAsync(doc => classrooms.Add(doc));

            return classrooms;
        }

        //----------------------------------------------------
        //---------------GetclassroomById--------------------
        //----------------------------------------------------
        public async Task<Classroom> GetclassroomById(String id)
        {

            var classroom = await ClassroomCollection.Find(u => u.IdClassroom == id).FirstOrDefaultAsync();
            return classroom;
        }
        //----------------------------------------------------
        //-----------------UpdateclassroombyId--------------------
        //----------------------------------------------------
        public async Task UpdateclassroombyId(String id, Classroom appclassroom)
        {
            var filter = Builders<Classroom>.Filter.Eq(classroom => classroom.IdClassroom, id);

            var update = Builders<Classroom>.Update
                           .Set(classroom => classroom.ClassroomName, appclassroom.ClassroomName);
                     


            await ClassroomCollection.UpdateOneAsync(filter, update);
        }

        //----------------------------------------------------
        //------------------AddClassroom----------------------
        //----------------------------------------------------

        public async Task InsertClassroom(Classroom classroom)
        {
            await ClassroomCollection.InsertOneAsync(classroom);
        }

        //----------------------------------------------------
        //------------------DeleteclassroomById----------------------
        //----------------------------------------------------
        public async Task Deleteclassroom(String id)
        {

            await ClassroomCollection.DeleteOneAsync(x => x.IdClassroom == id);
        }






    }
}
