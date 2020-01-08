using MongoDB.Bson;
using MongoDB.Driver;
using MyAwesomeWebApi.Models.Papras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAwesomeWebApi.Services
{
    public class PlugService
    {
        //----------------------------------------------------
        //----------------------------------------------------
        //----------------------------------------------------
        public IMongoCollection<Plug> PlugCollection { get; }

        public PlugService(string databaseName, string collectionName, string databaseUrl)
        {
            var mongoClient = new MongoClient(databaseUrl);
            var mongoDataBase = mongoClient.GetDatabase(databaseName);
            PlugCollection = mongoDataBase.GetCollection<Plug>(collectionName);
        }

        //----------------------------------------------------
        //-----------------GetAllPlugs-------------------
        //----------------------------------------------------
        public async Task<List<Plug>> GetAllPlugs()
        {
            var plugs = new List<Plug>();

            var allDocuments = await PlugCollection.FindAsync(new BsonDocument());

            await allDocuments.ForEachAsync(doc => plugs.Add(doc));

            return plugs;
        }

        //----------------------------------------------------
        //---------------GetPlugById--------------------
        //----------------------------------------------------
        public async Task<Plug> GetPlugById(String id)
        {

            var plug = await PlugCollection.Find(u => u.IdFile == id).FirstOrDefaultAsync();
            return plug;
        }
        //----------------------------------------------------
        //-----------------UpdatePlugbyId--------------------
        //----------------------------------------------------
        public async Task UpdatePlugbyId(String id, Plug appPlug)
        {
            var filter = Builders<Plug>.Filter.Eq(plug => plug.IdFile, id);

            var update = Builders<Plug>.Update
                           .Set(plug => plug.Type, appPlug.Type)
                           .Set(plug => plug.State, appPlug.State);

            await PlugCollection.UpdateOneAsync(filter, update);
        }

        //----------------------------------------------------
        //------------------AddPlug----------------------
        //----------------------------------------------------
        public async Task InsertPlug(Plug plug)
        {
            await PlugCollection.InsertOneAsync(plug);
        }

        //----------------------------------------------------
        //------------------DeletePlugById----------------------
        //----------------------------------------------------
        public async Task DeletePlug(String id)
        {

            await PlugCollection.DeleteOneAsync(x => x.IdFile == id);
        }

    }
}
