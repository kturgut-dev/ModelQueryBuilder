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
        public Query CreateQuery()
        {
            try
            {
                using (QueryFactoryDb = new QueryFactory(DBCconnection, QueryCompiler))
                {
                    return QueryFactoryDb.Query(TableName);
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public T ExecuteQuery(Query)
        {
            try
            {
                using (QueryFactoryDb = new QueryFactory(DBCconnection, QueryCompiler))
                {
                    return QueryFactoryDb.Query(TableName);
                }
            }
            catch (Exception ex)
            {
                return default(T);
            }
        }

        public bool Insert(T data)
        {
            try
            {
                using (QueryFactoryDb = new QueryFactory(DBCconnection, QueryCompiler))
                {
                    return QueryFactoryDb.Query(TableName)
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
                using (QueryFactoryDb = new QueryFactory(DBCconnection, QueryCompiler))
                {
                    return await QueryFactoryDb.Query(TableName)
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
                using (QueryFactoryDb = new QueryFactory(DBCconnection, QueryCompiler))
                {
                    return QueryFactoryDb.Query(TableName).InsertGetId<TId>(data);
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
                using (QueryFactoryDb = new QueryFactory(DBCconnection, QueryCompiler))
                {
                    return await QueryFactoryDb.Query(TableName).InsertGetIdAsync<TId>(data);
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
                using (QueryFactoryDb = new QueryFactory(DBCconnection, QueryCompiler))
                {
                    return query(QueryFactoryDb.Query(TableName))
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
                using (QueryFactoryDb = new QueryFactory(DBCconnection, QueryCompiler))
                {
                    return await conditions(QueryFactoryDb.Query(TableName))
                        .UpdateAsync(data) > 0;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Update(object data, Func<Query, Query> query)
        {
            try
            {
                using (QueryFactoryDb = new QueryFactory(DBCconnection, QueryCompiler))
                {
                    return query(QueryFactoryDb.Query(TableName))
                        .Update(data) > 0;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<bool> UpdateAsync(object data, Func<Query, Query> conditions)
        {
            try
            {
                using (QueryFactoryDb = new QueryFactory(DBCconnection, QueryCompiler))
                {
                    return await conditions(QueryFactoryDb.Query(TableName))
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
                using (QueryFactoryDb = new QueryFactory(DBCconnection, QueryCompiler))
                {
                    return query(QueryFactoryDb.Query(TableName))
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
                using (QueryFactoryDb = new QueryFactory(DBCconnection, QueryCompiler))
                {
                    return await conditions(QueryFactoryDb.Query(TableName))
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
                using (QueryFactoryDb = new QueryFactory(DBCconnection, QueryCompiler))
                {
                    return (conditions != null ? conditions(QueryFactoryDb.Query(TableName)).Get<T>() : QueryFactoryDb.Query(TableName).Get<T>());
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
                using (QueryFactoryDb = new QueryFactory(DBCconnection, QueryCompiler))
                {
                    return await (conditions != null ? conditions(QueryFactoryDb.Query(TableName)).GetAsync<T>() : QueryFactoryDb.Query(TableName).GetAsync<T>());
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
                using (QueryFactoryDb = new QueryFactory(DBCconnection, QueryCompiler))
                {
                    return conditions(QueryFactoryDb.Query(TableName)).First<T>();
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
                using (QueryFactoryDb = new QueryFactory(DBCconnection, QueryCompiler))
                {
                    return await conditions(QueryFactoryDb.Query(TableName)).FirstAsync<T>();
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
                using (QueryFactoryDb = new QueryFactory(DBCconnection, QueryCompiler))
                {
                    return query(QueryFactoryDb.Query(TableName)).Paginate<T>(page, perPage);
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
                using (QueryFactoryDb = new QueryFactory(DBCconnection, QueryCompiler))
                {
                    return await conditions(QueryFactoryDb.Query(TableName)).PaginateAsync<T>(page, perPage);
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
