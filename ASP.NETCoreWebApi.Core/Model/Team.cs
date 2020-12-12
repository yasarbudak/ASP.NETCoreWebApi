using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ASP.NETCoreWebApi.Core
{
  public class Team
  {
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    [BsonElement("teamId")]
    public int TeamId { get; set; }

    [BsonElement("abbreviation")]
    public string Abbrevation { get; set; }

    [BsonElement("teamName")]
    public string Name { get; set; }
    
    [BsonElement("simpleName")]
    public string Simplename { get; set; }

    [BsonElement("location")]
    public string Location { get; set; }

    

    


  }
}