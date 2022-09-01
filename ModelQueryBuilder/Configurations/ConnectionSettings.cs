using System.Configuration;

namespace ModelQueryBuilder.Configurations
{
    public class ConnectionSettings : ConfigurationElement
    {
        [ConfigurationProperty("type", IsRequired = true)]
        public string Type
        {
            get
            {
                return (string)this["type"];
            }
            set
            {
                value = (string)this["type"];
            }
        }

        [ConfigurationProperty("connection", IsRequired = true)]
        public string Connection
        {
            get
            {
                return (string)this["connection"];
            }
            set
            {
                value = (string)this["connection"];
            }
        }
    }
}
