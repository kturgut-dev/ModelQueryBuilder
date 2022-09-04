using System.Configuration;

namespace ModelQueryBuilder.Configurations
{
    public class ModelQueryBuilderSettings
    {
        private static ModelQueryBuilderSettings _ModelQueryBuilderSettings { get; set; }
        private static void CreateInstance()
        {
            if (_ModelQueryBuilderSettings == null)
                _ModelQueryBuilderSettings = new ModelQueryBuilderSettings();
        }
        public static ModelQueryBuilderSettings GetInstance()
        {
            CreateInstance();
            return _ModelQueryBuilderSettings;
        }

        public void DestroyInstance()
        {
            _ModelQueryBuilderSettings = null;
        }

        public static void SetInstance(ModelQueryBuilderSettings data)
        {
            _ModelQueryBuilderSettings = data;
            //ConnectionSettings.SetInstance(data.ConnectionSettings);
        }

        public ConnectionSettings ConnectionSettings { get; set; }

        //public static ModelQueryBuilderSettings GetInstance()
        //{
        //    return System.Configuration.ConfigurationManager.GetSection(nameof(ModelQueryBuilderSettings)) as ModelQueryBuilderSettings;
        //}
    }
}
