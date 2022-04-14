using System.Drawing.Printing;
using System.Runtime.InteropServices;
using FluentMigrator;

namespace ToxiCode.BuyIt.Api.DataLayer.Migrations;

[Migration(1)]
public class ItemsOrdersMigration : ForwardOnlyMigration
{
    public override void Up()
    {
        Create.Table("images")
            .WithColumn("id").AsGuid().PrimaryKey()
            .WithColumn("file_name").AsString().NotNullable()
            .WithColumn("description").AsString(512).Nullable()
            .WithColumn("url").AsString(512).NotNullable()
            .WithColumn("created_at").AsDateTime().WithDefault(SystemMethods.CurrentUTCDateTime)
            .WithColumn("deleted_at").AsDateTime().Nullable();
        
        MigrateUsers();
        MigrateItems();
        MigrateReviews();
        MigrateProperties();
        MigrateOrdersAndCheckout();
    }
    private void MigrateItems()
    {
        Create.Table("items")
            .WithColumn("id").AsInt64().PrimaryKey()
            .WithColumn("name").AsString().NotNullable()
            .WithColumn("description").AsString().NotNullable()
            .WithColumn("price").AsDecimal().NotNullable()
            .WithColumn("owner").AsGuid().ForeignKey("users", "id").NotNullable()
            .WithColumn("created_at").AsDateTime().NotNullable()
            .WithColumn("last_updated").AsDateTime().Nullable()
            .WithColumn("deleted_at").AsDateTime().Nullable();

        Create.Table("items_images")
            .WithColumn("id").AsInt64().Identity().PrimaryKey()
            .WithColumn("item_id").AsInt64().ForeignKey("items", "id")
            .WithColumn("image_id").AsGuid().ForeignKey("images", "id");
    }
    private void MigrateReviews()
    {
        Create.Table("reviews")
            .WithColumn("id").AsInt64().Identity().PrimaryKey()
            .WithColumn("rate").AsDecimal().NotNullable()
            .WithColumn("review_text_cons").AsString().Nullable()
            .WithColumn("review_text_pros").AsString().Nullable()
            .WithColumn("review_text_commentary").AsString().Nullable()
            .WithColumn("user_id").AsGuid().ForeignKey("users", "id").NotNullable()
            .WithColumn("item_id").AsInt64().ForeignKey("items", "id").NotNullable()
            .WithColumn("created_at").AsDateTime().WithDefault(SystemMethods.CurrentUTCDateTime);
    }
    private void MigrateProperties()
    {
        Execute.Sql("CREATE TYPE property_kind AS ENUM('String', 'Float', 'Number')");

        Create.Table("properties")
            .WithColumn("id").AsInt64().Identity().PrimaryKey()
            .WithColumn("name").AsString().NotNullable().Unique()
            .WithColumn("kind").AsCustom("property_kind").NotNullable();

        Create.Table("properties_values")
            .WithColumn("id").AsInt64().Identity().PrimaryKey()
            .WithColumn("property_id").AsInt64().NotNullable().ForeignKey("properties", "id")
            .WithColumn("item_id").AsInt64().NotNullable().ForeignKey("items", "id")
            .WithColumn("value").AsString().Nullable();
    }
    private void MigrateOrdersAndCheckout()
    {
        Create.Table("orders")
            .WithColumn("id").AsInt64().PrimaryKey()
            .WithColumn("user_id").AsGuid().ForeignKey("users", "id").NotNullable();
        
        Execute.Sql("CREATE TYPE checkout_status AS ENUM('Created', 'Payed', 'Cancelled')");

        Create.Table("checkouts")
            .WithColumn("id").AsInt64().PrimaryKey().Identity()
            .WithColumn("order_id").AsInt64().ForeignKey("orders", "id")
            .WithColumn("payment_amount").AsDecimal().NotNullable()
            .WithColumn("created_at").AsDateTime().WithDefault(SystemMethods.CurrentUTCDateTime)
            .WithColumn("payed_at").AsDateTime().Nullable()
            .WithColumn("cancelled_at").AsDateTime().Nullable();
    }
    private void MigrateUsers()
    {
        Create.Table("users")
            .WithColumn("id").AsGuid().PrimaryKey()
            .WithColumn("username").AsString().Unique()
            .WithColumn("name").AsString().NotNullable()
            .WithColumn("image_id").AsGuid().ForeignKey("images", "id")
            .WithColumn("created_at").AsDateTime().WithDefault(SystemMethods.CurrentUTCDateTime)
            .WithColumn("last_updated").AsDateTime().Nullable();
    }
}