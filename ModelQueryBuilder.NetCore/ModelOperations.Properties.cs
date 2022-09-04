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
        public IDbConnection DBCconnection { get; set; }
        public Compiler QueryCompiler { get; set; }
        public string TableName { get; set; }
        public QueryFactory QueryFactoryDb { get; set; }
    }
}
