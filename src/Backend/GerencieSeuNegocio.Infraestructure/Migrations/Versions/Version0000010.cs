using FluentMigrator;

namespace GerencieSeuNegocio.Infraestructure.Migrations.Versions
{
    [Migration(DatabaseVersions.TABLE_STAY_CUSTOMERS, "Create table to save the cash report's information.")]
    public class Version0000010 : VersionBase
    {
        public override void Up()
        {
            CreateTable(STAY_CUSTOMERS_TABLE_NAME)
                .WithColumn("StayId").AsInt32().NotNullable()
                .WithColumn("CustomerId").AsInt32().NotNullable()
                .WithColumn("IsPrimary").AsBoolean().NotNullable().WithDefaultValue(false);
        }
    }
}
