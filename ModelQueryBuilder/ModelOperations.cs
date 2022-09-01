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
    public class ModelOperations<T> : IModelOperations<T> where T : class, new()
    {
        public IDbConnection DBCconnection { get; set; }
        public Compiler QueryCompiler { get; set; }
        public string TableName { get; set; }

        public ModelOperations()
        {
            ModelQueryBuilderSettings modelQueryBuilderSettings = ModelQueryBuilderSettings.GetInstance();
            if (modelQueryBuilderSettings == null)
                throw new Exception("Configuration Setting undefined.");

            DBCconnection = modelQueryBuilderSettings.ConnectionSettings.GetConnection();
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

        #region Operation Methods
        public bool Insert(T data)
        {
            try
            {
                using (QueryFactory db = new QueryFactory(DBCconnection, QueryCompiler))
                {
                    return db.Query(TableName)
                        .Insert(data) > 0;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<bool> InsertAsync(T data)
        {
            try
            {
                using (QueryFactory db = new QueryFactory(DBCconnection, QueryCompiler))
                {
                    return await db.Query(TableName)
                        .InsertAsync(data) > 0;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public TId InsertGetId<TId>(T data)
        {
            try
            {
                using (QueryFactory db = new QueryFactory(DBCconnection, QueryCompiler))
                {
                    return db.Query(TableName).InsertGetId<TId>(data);
                }
            }
            catch (Exception ex)
            {
                return default(TId);
            }
        }
        public async Task<TId> InsertGetIdAsync<TId>(T data)
        {
            try
            {
                using (QueryFactory db = new QueryFactory(DBCconnection, QueryCompiler))
                {
                    return await db.Query(TableName).InsertGetIdAsync<TId>(data);
                }
            }
            catch (Exception ex)
            {
                return default(TId);
            }
        }

        public bool Update(T data, Func<Query, Query> query)
        {
            try
            {
                using (QueryFactory db = new QueryFactory(DBCconnection, QueryCompiler))
                {
                    return query(db.Query(TableName))
                        .Update(data) > 0;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<bool> UpdateAsync(T data, Func<Query, Query> conditions)
        {
            try
            {
                using (QueryFactory db = new QueryFactory(DBCconnection, QueryCompiler))
                {
                    return await conditions(db.Query(TableName))
                        .UpdateAsync(data) > 0;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(Func<Query, Query> query)
        {
            try
            {
                using (QueryFactory db = new QueryFactory(DBCconnection, QueryCompiler))
                {
                    return query(db.Query(TableName))
                        .Delete() > 0;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<bool> DeleteAsync(Func<Query, Query> conditions)
        {
            try
            {
                using (QueryFactory db = new QueryFactory(DBCconnection, QueryCompiler))
                {
                    return await conditions(db.Query(TableName))
                        .DeleteAsync() > 0;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public IEnumerable<T> GetAll(Func<Query, Query> conditions = null)
        {
            try
            {
                using (QueryFactory db = new QueryFactory(DBCconnection, QueryCompiler))
                {
                    return (conditions != null ? conditions(db.Query(TableName)).Get<T>() : db.Query(TableName).Get<T>());
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<IEnumerable<T>> GetAllAsync(Func<Query, Query> conditions = null)
        {
            try
            {
                using (QueryFactory db = new QueryFactory(DBCconnection, QueryCompiler))
                {
                    return await (conditions != null ? conditions(db.Query(TableName)).GetAsync<T>() : db.Query(TableName).GetAsync<T>());
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public T Get(Func<Query, Query> conditions)
        {
            try
            {
                using (QueryFactory db = new QueryFactory(DBCconnection, QueryCompiler))
                {
                    return conditions(db.Query(TableName)).First<T>();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<T> GetAsync(Func<Query, Query> conditions)
        {
            try
            {
                using (QueryFactory db = new QueryFactory(DBCconnection, QueryCompiler))
                {
                    return await conditions(db.Query(TableName)).FirstAsync<T>();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public PaginationResult<T> Paginate(Func<Query, Query> query, int page, int perPage = 25)
        {
            try
            {
                using (QueryFactory db = new QueryFactory(DBCconnection, QueryCompiler))
                {
                    return query(db.Query(TableName)).Paginate<T>(page, perPage);
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<PaginationResult<T>> PaginateAsync(Func<Query, Query> conditions, int page, int perPage = 25)
        {
            try
            {
                using (QueryFactory db = new QueryFactory(DBCconnection, QueryCompiler))
                {
                    return await conditions(db.Query(TableName)).PaginateAsync<T>(page, perPage);
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion
    }
}
