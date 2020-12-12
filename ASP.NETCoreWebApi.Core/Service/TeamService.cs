using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace ASP.NETCoreWebApi.Core
{
  public class TeamService
  {
    private readonly IMongoCollection<Team> _teams;

    public TeamService(IDbSettings mongoDbSettings)
    {
      MongoClient mongoClient = new MongoClient(mongoDbSettings.ConnectionString);
      var db = mongoClient.GetDatabase(mongoDbSettings.Database);
      _teams = db.GetCollection<Team>(mongoDbSettings.Collection);
    }

    public List<Team> GetAll() => _teams.Find(t => true).ToList();

    public Team GetSingle(string id) => _teams.Find(t => t.Id == id).FirstOrDefault();

    public Team Create(Team team)
    {
      if (team.Name != null)
      {
        _teams.InsertOne(team);
        return team;
      }
      else
      {
        return null;
      }
    }

    public long Delete(string id) => _teams.DeleteOne(i => i.Id == id).DeletedCount;

    public long Update(string id, Team currentTeam) => _teams.ReplaceOne(t => t.Id == id, currentTeam).ModifiedCount;
  }
}