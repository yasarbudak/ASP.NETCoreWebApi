﻿namespace ASP.NETCoreWebApi.Core
{
  public class MongoDbSettings
    : IDbSettings
  {
    public string ConnectionString { get; set; }
    public string Database { get; set; }
    public string Collection { get; set; }
  }
}