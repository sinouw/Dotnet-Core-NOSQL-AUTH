using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using MyAwesomeWebApi.Models.Papras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAwesomeWebApi.Services
{
    public class SubjectService
    {
        //----------------------------------------------------
        //----------------------------------------------------
        //----------------------------------------------------
        public IMongoCollection<Subject> SubjectCollection { get; }

        public SubjectService(string databaseName, string collectionName, string databaseUrl)
        {
            var mongoClient = new MongoClient(databaseUrl);
            var mongoDataBase = mongoClient.GetDatabase(databaseName);
            SubjectCollection = mongoDataBase.GetCollection<Subject>(collectionName);
        }

        //----------------------------------------------------
        //-----------------GetAllsubjects-------------------
        //----------------------------------------------------
        public async Task<List<Subject>> GetAllSubjects()
        {
            var subjects = new List<Subject>();

            var allDocuments = await SubjectCollection.FindAsync(new BsonDocument());

            await allDocuments.ForEachAsync(doc => subjects.Add(doc));

            return subjects;
        }

        //----------------------------------------------------
        //---------------GetSubjectById--------------------
        //----------------------------------------------------
        public async Task<Subject> GetSubjectById(String id)
        {

            var subject = await SubjectCollection.Find(u => u.SubjId == id).FirstOrDefaultAsync();
            return subject;
        }
        //----------------------------------------------------
        //-----------------UpdateSubjectbyId--------------------
        //----------------------------------------------------
        public async Task UpdatesubjectbyId(String id, Subject appsubject)
        {
            var filter = Builders<Subject>.Filter.Eq(subject => subject.SubjId, id);

            var update = Builders<Subject>.Update
                           .Set(subject => subject.SubjName, appsubject.SubjName);



            await SubjectCollection.UpdateOneAsync(filter, update);
        }
        
        //----------------------------------------------------
        //------------------AddSubject----------------------
        //----------------------------------------------------

        public async Task InsertSubject(Subject subject)
        {
            await SubjectCollection.InsertOneAsync(subject);
        }

        //----------------------------------------------------
        //------------------DeleteSubjectById----------------------
        //----------------------------------------------------
        public async Task Deletesubject(String id)
        {
            await SubjectCollection.DeleteOneAsync(x => x.SubjId == id);
        }

    }
}
