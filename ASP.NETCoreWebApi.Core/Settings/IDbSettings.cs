namespace ASP.NETCoreWebApi.Core
{
  public interface IDbSettings
  {
    string ConnectionString { get; set; }
    string Database { get; set; }
    string Collection { get; set; }
  }
}