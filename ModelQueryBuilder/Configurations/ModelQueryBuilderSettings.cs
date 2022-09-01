using System.Configuration;

namespace ModelQueryBuilder.Configurations
{
    public class ModelQueryBuilderSettings : System.Configuration.ConfigurationSection
    {
        [ConfigurationProperty("ConnectionSettings")]
        public ConnectionSettings ConnectionSettings
        {
            get
            {
                return (ConnectionSettings)this["ConnectionSettings"];
            }
            set
            {
                value = (ConnectionSettings)this["ConnectionSettings"];
            }
        }

        public static ModelQueryBuilderSettings GetInstance()
        {
            return System.Configuration.ConfigurationManager.GetSection(nameof(ModelQueryBuilderSettings)) as ModelQueryBuilderSettings;
        }

    }
}
