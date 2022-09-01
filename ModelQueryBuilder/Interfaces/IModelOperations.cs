using SqlKata;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ModelQueryBuilder.Interfaces
{
    public interface IModelOperations<T> where T : class, new()
    {
        System.Data.IDbConnection DBCconnection { get; set; }
        SqlKata.Compilers.Compiler QueryCompiler { get; set; }
        string TableName { get; set; }

        bool Insert(T data);
        Task<bool> InsertAsync(T data);

        TId InsertGetId<TId>(T data);
        Task<TId> InsertGetIdAsync<TId>(T data);

        bool Update(T data, Func<Query, Query> conditions);
        Task<bool> UpdateAsync(T data, Func<Query, Query> conditions);

        bool Delete(Func<Query, Query> conditions);
        Task<bool> DeleteAsync(Func<Query, Query> conditions);

        IEnumerable<T> GetAll(Func<Query, Query> conditions);
        Task<IEnumerable<T>> GetAllAsync(Func<Query, Query> conditions);

        T Get(Func<Query, Query> conditions);
        Task<T> GetAsync(Func<Query, Query> conditions);

        SqlKata.Execution.PaginationResult<T> Paginate(Func<Query, Query> conditions, int page, int perPage = 25);
        Task<SqlKata.Execution.PaginationResult<T>> PaginateAsync(Func<Query, Query> conditions, int page, int perPage = 25);
    }
}
