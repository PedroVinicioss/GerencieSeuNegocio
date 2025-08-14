using FluentMigrator;

namespace GerencieSeuNegocio.Infraestructure.Migrations.Versions
{
    [Migration(DatabaseVersions.TABLE_CASH_REPORTS, "Create table to save the room's information.")]
    public class Version0000005 : VersionBase
    {
        public override void Up()
        {
            CreateTable(CASH_REPORTS_TABLE_NAME)
                .WithColumn("BusinessId").AsInt64().NotNullable().ForeignKey("FK_CashReports_Business_Id", BUSINESS_TABLE_NAME, "Id")
                .WithColumn("Description").AsString(500).Nullable()
                .WithColumn("Type").AsInt32().NotNullable().WithDefaultValue(0)
                .WithColumn("Amount").AsDecimal().NotNullable().WithDefaultValue(0.0m)
                .WithColumn("Date").AsDateTime().NotNullable().WithDefaultValue(SystemMethods.CurrentUTCDateTime);
        }
    }
}
