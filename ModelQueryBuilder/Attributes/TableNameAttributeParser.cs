using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelQueryBuilder.Attributes
{
    public static class TableNameAttributeParser
    {
        public static string GetTableName<T>() where T : class, new()
        {
            TableNameAttribute attribute = (TableNameAttribute)typeof(T).GetCustomAttributes(true).FirstOrDefault(attr => attr is TableNameAttribute);
            return attribute != null ? attribute.TableName : string.Format("{0}s", typeof(T).Name.ToLower()); ;
        }

        public static bool HasTableName<T>() where T : class, new()
        {
            return typeof(T).GetCustomAttributes(true).Any(attr => attr is TableNameAttribute);
        }
    }
}
