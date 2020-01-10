using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using MyAwesomeWebApi.Models.Auth.Identity.Roles;
using MyAwesomeWebApi.Models.Auth.Settings;
using MyAwesomeWebApi.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAwesomeWebApi.Models
{
    public class UserService
    {
     
        public UserService(string databaseName, string collectionName, string databaseUrl)
        {
            var mongoClient = new MongoClient(databaseUrl);
            var mongoDataBase = mongoClient.GetDatabase(databaseName);
            UsersCollection = mongoDataBase.GetCollection<ApplicationUser>(collectionName);
            StudentsCollection = mongoDataBase.GetCollection<Student>(collectionName);
        }


        //----------------------------------------------------
        //----------------------------------------------------
        //----------------------------------------------------
        public IMongoCollection<ApplicationUser> UsersCollection { get; }
        public IMongoCollection<Student> StudentsCollection { get; }

        //----------------------------------------------------
        //-----------------GetAllUsers-------------------
        //----------------------------------------------------
        public async Task<List<ApplicationUser>> GetAllUsers()
        {
            var docs = await UsersCollection.Find(_ => true).ToListAsync();

            return docs;
        }

        //----------------------------------------------------
        //-----------------GetOneUser-------------------
        //----------------------------------------------------
        public async Task<ApplicationUser> GetOneUserByemail(string email)
        {
            ApplicationUser doc = await UsersCollection.Find(_ => _.Email == email).FirstOrDefaultAsync();

            return doc;
        }

        //----------------------------------------------------
        //-----------------GetOneUserRole-------------------
        //----------------------------------------------------
        public async Task<string> GetOneUserRoleByemail(string email)
        {
            ApplicationUser doc = await UsersCollection.Find(_ => _.Email == email).FirstOrDefaultAsync();

            return doc.Roles[0];
        }


        ////----------------------------------------------------
        ////-----------------GetAllStudents-------------------
        ////----------------------------------------------------
        //public async Task<List<Student>> GetAllStudents()
        //{
        //    //var docs = await StudentsCollection.Find(_ => true).ToListAsync();
        //    //var documents = await StudentsCollection.Find(Builders<Student>.Filter.Empty).ToListAsync();
        //    var documents = await StudentsCollection.Find(Builders<Student>.Filter.Empty).ToListAsync();
        //    return documents;
        //}

        //----------------------------------------------------
        //---------------GetUserById--------------------
        //----------------------------------------------------
        public async Task<ApplicationUser> GetUserById(string id)
        {

            var user = await UsersCollection.Find(u => u.Id == id).FirstOrDefaultAsync();
            return user;
        }
        //----------------------------------------------------
        //-----------------UpdateUserbyId--------------------
        //----------------------------------------------------
        public async Task UpdateUserbyId(string id, ApplicationUser appuser)
        {
            var filter = Builders<ApplicationUser>.Filter.Eq(user => user.Id, id);

            var update = Builders<ApplicationUser>.Update
                           .Set(user => user.LastName, appuser.LastName)
                           .Set(user => user.City, appuser.City)
                           .Set(user => user.PhoneNumber, appuser.PhoneNumber)
                           .Set(user => user.Name, appuser.Name)
                           .Set(user => user.Enabled, appuser.Enabled);


            await UsersCollection.UpdateOneAsync(filter, update);
        }

        //----------------------------------------------------
        //------------------DeleteUserById----------------------
        //----------------------------------------------------
        public async Task DeleteUser(string id)
        {

            await UsersCollection.DeleteOneAsync(x => x.Id == id);
        }

      

    }
}
