SqlKata Kütüphanesi baz alınarak üstüne geliştirildi.

**Program.cs**

	AuthorOperations authorOp = new AuthorOperations();
    //IEnumerable<Author> authors = await authorOp.GetAllAsync();
    IEnumerable<Author> authorsTest = await authorOp.CreateQuery()
          .GetAsync<Author>();

    foreach (Author author in authorsTest)
    {
        Console.WriteLine(author.FullName);
    }

     Console.ReadKey();

**Config File**

    <configSections>
		<section name="ModelQueryBuilderSettings" type="ModelQueryBuilder.Configurations.ModelQueryBuilderSettings, ModelQueryBuilder"/>
	</configSections>

	<ModelQueryBuilderSettings>
		<ConnectionSettings type="MySql" connection="Server=localhost;Database=sqlkata_example;Uid=root;Pwd=;" />
	</ModelQueryBuilderSettings>


TOperation Class Example

    public class AuthorOperations : ModelOperations<Author>
    {
        public AuthorOperations() : base()
        {

        }
    }

