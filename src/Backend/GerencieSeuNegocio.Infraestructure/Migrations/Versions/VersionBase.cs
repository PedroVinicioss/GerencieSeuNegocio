using FluentMigrator;
using FluentMigrator.Builders.Create.Table;

namespace GerencieSeuNegocio.Infraestructure.Migrations.Versions
{
    public abstract class VersionBase : ForwardOnlyMigration
    {
        protected const string USER_TABLE_NAME = "Users";
        protected const string BUSINESS_TABLE_NAME = "Business";
        protected const string CUSTOMERS_TABLE_NAME = "Customers";

        public ICreateTableColumnOptionOrWithColumnSyntax CreateTable(string table)
        {
            return Create.Table(table)
                .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("Uuid").AsGuid().NotNullable().Unique()
                .WithColumn("CreatOn").AsDateTime().NotNullable()
                .WithColumn("Active").AsBoolean().NotNullable();
        }
    }
}
