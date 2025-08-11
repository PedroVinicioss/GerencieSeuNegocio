using FluentMigrator;

namespace GerencieSeuNegocio.Infraestructure.Migrations.Versions
{
    [Migration(DatabaseVersions.TABLE_CUSTOMERS, "Create table to save the business's information.")]
    public class Version0000003 : VersionBase
    {
        public override void Up()
        {
            CreateTable(CUSTOMERS_TABLE_NAME)
                .WithColumn("BusinessId").AsInt64().NotNullable().ForeignKey("FK_Customers_Business_Id", BUSINESS_TABLE_NAME, "Id")
                .WithColumn("Name").AsString(255).NotNullable()
                .WithColumn("Email").AsString(255).NotNullable()
                .WithColumn("Phone").AsString(50).NotNullable()
                .WithColumn("Address").AsString(500).Nullable();
        }
    }
}
