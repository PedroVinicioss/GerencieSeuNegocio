using FluentMigrator;

namespace GerencieSeuNegocio.Infraestructure.Migrations.Versions
{
    [Migration(DatabaseVersions.TABLE_STAYS, "Create table to save the cash report's information.")]
    public class Version0000009 : VersionBase
    {
        public override void Up()
        {
            CreateTable(STAYS_TABLE_NAME)
                .WithColumn("BusinessId").AsInt32().NotNullable()
                .WithColumn("RoomId").AsInt32().NotNullable()
                .WithColumn("CheckInDate").AsDateTime().NotNullable()
                .WithColumn("CheckOutDate").AsDateTime().NotNullable()
                .WithColumn("TotalAmount").AsDecimal().NotNullable().WithDefaultValue(0.0m)
                .WithColumn("Status").AsInt16().NotNullable().WithDefaultValue(0) 
                .WithColumn("PaymentMethod").AsInt16().NotNullable().WithDefaultValue(0);
        }
    }
}
