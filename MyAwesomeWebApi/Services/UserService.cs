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
        }


        //----------------------------------------------------
        //----------------------------------------------------
        //----------------------------------------------------
        public IMongoCollection<ApplicationUser> UsersCollection { get; }

        //----------------------------------------------------
        //-----------------GetAllUsers-------------------
        //----------------------------------------------------
        public async Task<List<ApplicationUser>> GetAllUsers()
        {
            var users = new List<ApplicationUser>();

            var allDocuments = await UsersCollection.FindAsync(new BsonDocument());

            await allDocuments.ForEachAsync(doc => users.Add(doc));

            return users;
        }

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
