using FluentMigrator;

namespace GerencieSeuNegocio.Infraestructure.Migrations.Versions
{
    [Migration(DatabaseVersions.TABLE_ROOMS, "Create table to save the room's information.")]
    public class Version0000004 : VersionBase
    {
        public override void Up()
        {
            CreateTable(ROOMS_TABLE_NAME)
                .WithColumn("BusinessId").AsInt64().NotNullable().ForeignKey("FK_Rooms_Business_Id", BUSINESS_TABLE_NAME, "Id")
                .WithColumn("Name").AsString(255).NotNullable()
                .WithColumn("Description").AsString(500).Nullable()
                .WithColumn("Capacity").AsInt32().NotNullable()
                .WithColumn("IsAvailable").AsBoolean().NotNullable().WithDefaultValue(true);
        }
    }
}
