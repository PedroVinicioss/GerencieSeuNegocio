using FluentMigrator;

namespace GerencieSeuNegocio.Infraestructure.Migrations.Versions
{
    [Migration(DatabaseVersions.TABLE_SALES, "Create table to save the sale's information.")]
    public class Version0000007 : VersionBase
    {
        public override void Up()
        {
            CreateTable(SALES_TABLE_NAME)
                .WithColumn("BusinessId").AsInt64().NotNullable().ForeignKey("FK_Sales_Business_Id", BUSINESS_TABLE_NAME, "Id")
                .WithColumn("CustomerId").AsInt64().Nullable().ForeignKey("FK_Sales_Customers_Id", CUSTOMERS_TABLE_NAME, "Id")
                .WithColumn("TotalAmount").AsDecimal().NotNullable().WithDefaultValue(0.0m)
                .WithColumn("Status").AsInt32().NotNullable().WithDefaultValue(0)
                .WithColumn("PaymentMethod").AsInt32().NotNullable().WithDefaultValue(0);
        }
    }
}
