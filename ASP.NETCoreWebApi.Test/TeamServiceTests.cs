using ASP.NETCoreWebApi.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace ASP.NETCoreWebApi.Test
{
  [TestClass]
  public class TeamServiceTests
  {
    private TeamService service;

    [TestInitialize]
    public void Setup()
    {
      IDbSettings settings = new MongoDbSettings
      {
        ConnectionString = "mongodb://localhost:27017",
        Database = "NBADatabase",
        Collection = "teams"
      };

      service = new TeamService(settings);
    }

    [TestMethod]
    public void GetAll_Should_Return_Teams()
    {
      List<Team> teams = service.GetAll();
      Assert.AreNotEqual(0, teams.Count);
    }

    [TestMethod]
    public void GetSingle_Should_Return_Any_Team_By_Id()
    {
      string id = "5fd486f54a056b9378d105eb";
      Team team = service.GetSingle(id);
      Assert.AreNotEqual(null, team);
      Assert.AreEqual("Brooklyn Nets", team.Name);
    }

    [TestMethod]
    public void Create_Should_Insert_New_Team()
    {
      Team team = new Team();
      var inserted = service.Create(team);
      Assert.AreNotEqual(0, inserted.Id);
      Assert.AreEqual(24, inserted.Id.Length);
    }

    [TestMethod]
    public void Delete_Should_Remove_Team()
    {
      var id = "5fd486f54a056b9378d105eb";
      long deletedCount = service.Delete(id);
      Assert.AreEqual(1, deletedCount);
    }

    [TestMethod]
    public void Update_Should_Change_Team_Info()
    {
      string id = "5fd486f54a056b9378d105eb";
      Team currentTeam = new Team
      {
        Id = "5fd486f54a056b9378d105eb",
        TeamId = 1610612737,
        Abbrevation = "BKN",
        Name = "Brooklyn Nets",
        Simplename = "Nets",
        Location = "Brooklyn",
      };
      long updatedCount = service.Update(id, currentTeam);
      Assert.AreEqual(1, updatedCount);
    }
  }
}
