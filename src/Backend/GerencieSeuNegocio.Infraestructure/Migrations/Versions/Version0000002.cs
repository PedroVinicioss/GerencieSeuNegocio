using FluentMigrator;

namespace GerencieSeuNegocio.Infraestructure.Migrations.Versions
{
    [Migration(DatabaseVersions.TABLE_BUSINESS, "Create table to save the business's information.")]

    public class Version0000002 : VersionBase
    {
        public override void Up()
        {
            CreateTable(BUSINESS_TABLE_NAME)
                .WithColumn("UserId").AsInt64().NotNullable().ForeignKey("FK_Business_User_Id", USER_TABLE_NAME, "Id")
                .WithColumn("Name").AsString(255).NotNullable()
                .WithColumn("Type").AsInt64().NotNullable();
        }
    }
}
