using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using ModelQueryBuilder.Attributes;
using ModelQueryBuilder.Configurations;
using ModelQueryBuilder.Extensions;
using ModelQueryBuilder.Interfaces;
using SqlKata;
using SqlKata.Compilers;
using SqlKata.Execution;

namespace ModelQueryBuilder
{
    public partial class ModelOperations<T> : IModelOperations<T> where T : class, new()
    {
        public ModelOperations()
        {
            ModelQueryBuilderSettings modelQueryBuilderSettings = ModelQueryBuilderSettings.GetInstance();
            if (modelQueryBuilderSettings == null)
                throw new Exception("Configuration Setting undefined.");

            DBCconnection = modelQueryBuilderSettings.ConnectionSettings.GetConnection();
            QueryCompiler = modelQueryBuilderSettings.ConnectionSettings.GetCompiler();
            TableName = TableNameAttributeParser.GetTableName<T>();
        }

        //for encrypted relationships
        public ModelOperations(string connectionString)
        {
            ModelQueryBuilderSettings modelQueryBuilderSettings = ModelQueryBuilderSettings.GetInstance();
            if (modelQueryBuilderSettings == null)
                throw new Exception("Configuration Setting undefined.");

            DBCconnection = modelQueryBuilderSettings.ConnectionSettings.GetConnection(connectionString);
            QueryCompiler = modelQueryBuilderSettings.ConnectionSettings.GetCompiler();
            TableName = TableNameAttributeParser.GetTableName<T>();
        }

        public ModelOperations(IDbConnection connection)
        {
            DBCconnection = connection;
            QueryCompiler = connection.GetCompiler();
            TableName = TableNameAttributeParser.GetTableName<T>();
        }

        public ModelOperations(IDbConnection connection, string tableName)
        {
            DBCconnection = connection;
            QueryCompiler = connection.GetCompiler();
            TableName = tableName;
        }

        public ModelOperations(IDbConnection connection, Compiler compiler)
        {
            DBCconnection = connection;
            QueryCompiler = compiler;
            TableName = TableNameAttributeParser.GetTableName<T>();
        }

        public ModelOperations(IDbConnection connection, Compiler compiler, string tableName)
        {
            DBCconnection = connection;
            QueryCompiler = compiler;
            TableName = tableName;
        }

    }
}
