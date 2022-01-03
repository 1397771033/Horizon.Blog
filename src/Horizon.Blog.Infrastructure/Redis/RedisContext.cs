using Microsoft.Extensions.Configuration;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Horizon.Blog.Infrastructure.Redis
{
    public class RedisContext : AbstructRedisContext, IRedisContext
    {
        public RedisContext(IConfiguration configuration)
            : base(configuration["ConnectionStrings:Redis"])
        {

        }

        public string StringGet(string key)
        {
            return Database.StringGet(key);
        }

        public bool StringSet(string key, string value, TimeSpan? expiry = null)
        {
            return Database.StringSet(key, value, expiry);
        }
    }
    public abstract class AbstructRedisContext
    {
        protected IDatabase Database { get; private set; }
        private ConnectionMultiplexer _connection;
        private string _conn;
        protected AbstructRedisContext(string connStr)
        {
            _conn = connStr;
            Connection();
            SetDatabase();
        }
        protected void SetDatabase(int db = -1)
        {
            if (_connection == null)
                Connection();
            Database = _connection.GetDatabase(db);
        }
        private void Connection()
        {
            _connection = ConnectionMultiplexer.Connect(_conn);

        }
    }
    public interface IRedisContext
    {
        bool StringSet(string key, string value, TimeSpan? expiry = null);
        string StringGet(string key);
    }
}
