using FluentMigrator;
using FluentMigrator.Builders.Create.Table;

namespace GerencieSeuNegocio.Infraestructure.Migrations.Versions
{
    public abstract class VersionBase : ForwardOnlyMigration
    {
        protected const string USER_TABLE_NAME = "Users";
        protected const string BUSINESS_TABLE_NAME = "Business";
        protected const string CUSTOMERS_TABLE_NAME = "Customers";
        protected const string ROOMS_TABLE_NAME = "Rooms";
        protected const string CASH_REPORTS_TABLE_NAME = "CashReports";
        protected const string PRODUCTS_TABLE_NAME = "Products";
        protected const string SALES_TABLE_NAME = "Sales";
        protected const string SALE_ITEMS_TABLE_NAME = "SaleItems";
        protected const string STAYS_TABLE_NAME = "Stays";
        protected const string STAY_CUSTOMERS_TABLE_NAME = "StayCustomers";

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
