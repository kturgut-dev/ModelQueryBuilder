using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelQueryBuilder.Extensions
{
    public static class IDbConnectionExtensions
    {
        public static SqlKata.Compilers.Compiler GetCompiler(this System.Data.IDbConnection data)
        {
            if (data is MySql.Data.MySqlClient.MySqlConnection)
                return new SqlKata.Compilers.MySqlCompiler();
            else if (data is Microsoft.Data.Sqlite.SqliteConnection)
                return new SqlKata.Compilers.SqliteCompiler();
            else if (data is System.Data.SqlClient.SqlConnection)
                return new SqlKata.Compilers.SqlServerCompiler();
            else
                throw new Exception("Bağlantı tipi bulunamadı ya da destek mevcut değil.");
        }
    }
}
