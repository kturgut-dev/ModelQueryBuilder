# ModelQueryBuilder

SqlKata Kütüphanesi baz alınarak üstüne geliştirildi.<br>

Program.cs
<code>
AuthorOperations authorOp = new AuthorOperations();
            //IEnumerable<Author> authors = await authorOp.GetAllAsync();
            IEnumerable<Author> authorsTest = await authorOp.CreateQuery()
                .GetAsync<Author>();

            foreach (Author author in authorsTest)
            {
                Console.WriteLine(author.FullName);
            }

            Console.ReadKey();
</code>

Config File
<code>
	<configSections>
		<section name="ModelQueryBuilderSettings" type="ModelQueryBuilder.Configurations.ModelQueryBuilderSettings, ModelQueryBuilder"/>
	</configSections>

	<ModelQueryBuilderSettings>
		<ConnectionSettings type="MySql" connection="Server=localhost;Database=sqlkata_example;Uid=root;Pwd=;" />
	</ModelQueryBuilderSettings>
</code>
