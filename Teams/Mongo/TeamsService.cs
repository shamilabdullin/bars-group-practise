using Teams.Mongo.Model;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Teams.Mongo
{
    public class TeamsService
    {
        private IMongoCollection<Team> _teams;

        public TeamsService()
        {
            string connection = "mongodb://localhost:27017/teamsDataBase";

            MongoUrlBuilder builder = new MongoUrlBuilder(connection);

            MongoClient client = new MongoClient(connection);

            IMongoDatabase db = client.GetDatabase(builder.DatabaseName);

            _teams = db.GetCollection<Team>("teams");
        }

        public async Task<Team> Get(string id)
        {
            return await _teams.Find(new BsonDocument("_id", new ObjectId(id))).FirstOrDefaultAsync();
        }

        public async Task<string> Create(Team teamModel)
        {
            await _teams.InsertOneAsync(teamModel);

            return teamModel.Id;
        }

        public async Task Update(Team teamModel)
        {
            await _teams.ReplaceOneAsync(new BsonDocument("_id", new ObjectId(teamModel.Id)), teamModel);
        }

        public async Task Delete(string id)
        {
            await _teams.DeleteOneAsync(new BsonDocument("_id", new ObjectId(id)));
        }
    }
}
