using StackExchange.Redis;

namespace Redis
{
    public class RedisConnectorHelper
    {
        private static Lazy<ConnectionMultiplexer> lazyConnection;
        
        public static ConnectionMultiplexer Connection
        {
            get
            {
                return lazyConnection.Value;
            }
        }
     
        static RedisConnectorHelper()
        {
            RedisConnectorHelper.lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
            {
                return ConnectionMultiplexer.Connect("localhost");
            });
        }
    }
}
