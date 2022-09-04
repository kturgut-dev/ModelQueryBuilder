using System;
using System.Configuration;

namespace ModelQueryBuilder.Configurations
{
    public class ConnectionSettings : IDisposable
    {
        private static ConnectionSettings _connectionSettings { get; set; }
        private static void CreateInstance()
        {
            if (_connectionSettings == null)
                _connectionSettings = new ConnectionSettings();
        }
        public static ConnectionSettings GetInstance()
        {
            CreateInstance();
            return _connectionSettings;
        }

        public void DestroyInstance()
        {
            _connectionSettings = null;
            GC.SuppressFinalize(this);
        }

        public void Dispose()
        {
            DestroyInstance();
        }

        public static void SetInstance(ConnectionSettings data)
        {
            _connectionSettings = data;
        }

        public string Type { get; set; }
        public string Connection { get; set; }
    }
}
