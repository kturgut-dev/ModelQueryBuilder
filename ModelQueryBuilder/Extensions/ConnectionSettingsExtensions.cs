﻿using ModelQueryBuilder.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelQueryBuilder.Extensions
{
    public static class ConnectionSettingsExtensions
    {
        public static SqlKata.Compilers.Compiler GetCompiler(this ConnectionSettings data)
        {
            switch (data.Type)
            {
                case "MySql":
                    return new SqlKata.Compilers.MySqlCompiler();
                case "Sqlite":
                    return new SqlKata.Compilers.SqliteCompiler();
                case "SqlServer":
                    return new SqlKata.Compilers.SqlServerCompiler();
                //case "Postgres":
                //   return new SqlKata.Compilers.PostgresCompiler();
                default:
                    throw new Exception("Bağlantı tipi bulunamadı ya da destek mevcut değil.");
            }
        }

        public static System.Data.IDbConnection GetConnection(this ConnectionSettings data)
        {
            switch (data.Type)
            {
                case "MySql":
                    return new MySql.Data.MySqlClient.MySqlConnection(data.Connection);
                case "Sqlite":
                    return new Microsoft.Data.Sqlite.SqliteConnection(data.Connection);
                case "SqlServer":
                    return new System.Data.SqlClient.SqlConnection(data.Connection);
                default:
                    throw new Exception("Bağlantı tipi bulunamadı.");
            }
        }
    }
}
