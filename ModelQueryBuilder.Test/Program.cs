using SqlKata;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelQueryBuilder.Test
{
    class Program
    {
        static async Task Main(string[] args)
        {
            AuthorOperations authorOp = new AuthorOperations();
            //IEnumerable<Author> authors = await authorOp.GetAllAsync();
            IEnumerable<Author> authorsTest = await authorOp.CreateQuery()
                .WhereLike("FullName", "K%")
                .GetAsync<Author>();

            foreach (Author author in authorsTest)
            {
                Console.WriteLine(author.FullName);
            }

            Console.ReadKey();
        }
    }
}
