using FluentMigrator;

namespace GerencieSeuNegocio.Infraestructure.Migrations.Versions
{
    [Migration(DatabaseVersions.TABLE_SALE_ITEMS, "Create table to save the cash sale item's information.")]
    public class Version0000008 : VersionBase
    {
        public override void Up()
        {
            CreateTable(SALE_ITEMS_TABLE_NAME)
                .WithColumn("SaleId").AsInt64().NotNullable().ForeignKey("FK_SaleItems_Sales_Id", SALES_TABLE_NAME, "Id")
                .WithColumn("ProductId").AsInt64().NotNullable().ForeignKey("FK_SaleItems_Products_Id", PRODUCTS_TABLE_NAME, "Id")
                .WithColumn("Quantity").AsInt32().NotNullable().WithDefaultValue(1)
                .WithColumn("UnitPrice").AsDecimal().NotNullable().WithDefaultValue(0.0m)
                .WithColumn("TotalAmount").AsDecimal().NotNullable().WithDefaultValue(0.0m);
        }
    }
}
