using StackExchange.Redis;
using Microsoft.Extensions.Configuration;

public class RedisService
{
    private readonly IConfiguration _config;
    private readonly string _connectionString;
    private readonly string _instanceName;

    public RedisService(IConfiguration config)
    {
        _config = config;
        _connectionString = _config.GetValue<string>("RedisSettings:ConnectionString");
        _instanceName = _config.GetValue<string>("RedisSettings:InstanceName");
        
        Console.WriteLine("Trying to connect Redis using connection string : {0}",_connectionString);
    }

    public void SetValue(string key, string value)
    {
        
        using (var connection = ConnectionMultiplexer.Connect(_connectionString))
        {
            var db = connection.GetDatabase();
            db.StringSet($"{_instanceName}:{key}", value);
            Console.WriteLine("Set Redis Key : {0} and Value : {1}",key,value);
        }
    }

    public string GetValue(string key)
    {
        using (var connection = ConnectionMultiplexer.Connect(_connectionString))
        {
            var db = connection.GetDatabase();
            string value = db.StringGet($"{_instanceName}:{key}");
            Console.WriteLine("Get Redis Key : {0} and Value : {1}",key,value);
            return value;
            
        }
    }
}
