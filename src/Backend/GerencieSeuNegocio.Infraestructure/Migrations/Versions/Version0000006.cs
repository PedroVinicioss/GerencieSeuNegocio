using FluentMigrator;

namespace GerencieSeuNegocio.Infraestructure.Migrations.Versions
{
    [Migration(DatabaseVersions.TABLE_PRODUCTS, "Create table to save the product's information.")]
    public class Version0000006 : VersionBase
    {
        public override void Up()
        {
            CreateTable(PRODUCTS_TABLE_NAME)
                .WithColumn("BusinessId").AsInt64().NotNullable().ForeignKey("FK_Products_Business_Id", BUSINESS_TABLE_NAME, "Id")
                .WithColumn("Name").AsString(100).NotNullable()
                .WithColumn("Price").AsDecimal().NotNullable().WithDefaultValue(0.0m)
                .WithColumn("Category").AsInt32().NotNullable().WithDefaultValue(0);
        }
    }
}
