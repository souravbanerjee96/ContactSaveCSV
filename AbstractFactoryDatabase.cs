using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Caching;
using Microsoft.AspNetCore.Builder;
using System.Runtime.InteropServices;
using Microsoft.Extensions.Primitives;

public interface IDatabaseConnectionFactory
{
    public string GetConnectionString();
}

public class MySqlConnectionFactory : IDatabaseConnectionFactory
{
    public string GetConnectionString() { return "Server=localhost;Database=MyDb;User Id=myuser;Password=mypassword;"; }

}
public class MongoConnectionFactory : IDatabaseConnectionFactory
{
    public string GetConnectionString() { return "mongodb://localhost:27017/MyDb"; }
}

public class Repository
{
    private readonly string _connectionString;
    public Repository(IDatabaseConnectionFactory databaseConnectionFactory)
    {
        _connectionString = databaseConnectionFactory.GetConnectionString();
    }
    public void GetData()
    {
        Console.WriteLine($"Connection = {_connectionString}");
        Console.WriteLine("Data Fetched...");
    }

}

public class RepositoryFactory
{
    public IDatabaseConnectionFactory getRepository(string rep)
    {
        switch (rep.ToLower())
        {
            case "mysql":
                return new MySqlConnectionFactory();
            case "mongo":
                return new MongoConnectionFactory();
            default:
                throw new NotImplementedException("No Connection as such...");
        }
    }
}

public class Program
    {
        public static void Main(string[] args)
        {
        RepositoryFactory RepositoryFactory = new();
        Repository sqlRepository = new(RepositoryFactory.getRepository("mysql"));
        sqlRepository.GetData();
        Repository mongoRepository = new(RepositoryFactory.getRepository("mongo"));
        mongoRepository.GetData();
    }
    }
