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
            IEnumerable<Author> authors = await authorOp.GetAllAsync();

            foreach (Author author in authors)
            {
                Console.WriteLine(author.FullName);
            }

            Console.ReadKey();
        }
    }
}
