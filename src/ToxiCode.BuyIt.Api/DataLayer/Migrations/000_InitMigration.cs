using FluentMigrator;
using JetBrains.Annotations;

namespace ToxiCode.BuyIt.Api.DataLayer.Migrations;

[Migration(0)]
[UsedImplicitly]
public class InitMigration : ForwardOnlyMigration
{
    public override void Up()
    {
        Create.Table("telegram_users")
            .WithColumn("id").AsInt64().Identity().PrimaryKey()
            .WithColumn("user_id").AsInt64().Unique();
        
        Create.Table("telegram_users_states")
            .WithColumn("id").AsInt64().Identity().PrimaryKey()
            .WithColumn("user_id").AsInt64().Unique().ForeignKey("telegram_users", "user_id")
            .WithColumn("states_chain").AsString(255);
    }
}