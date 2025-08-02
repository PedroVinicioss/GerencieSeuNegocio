using FluentMigrator;
using FluentMigrator.Builders.Create.Table;

namespace GerencieSeuNegocio.Infraestructure.Migrations.Versions
{
    public abstract class VersionBase : ForwardOnlyMigration
    {
        public ICreateTableColumnOptionOrWithColumnSyntax CreateTable(string table)
        {
            return Create.Table(table)
                .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("CreatOn").AsDateTime().NotNullable()
                .WithColumn("Active").AsBoolean().NotNullable();
        }
    }
}
