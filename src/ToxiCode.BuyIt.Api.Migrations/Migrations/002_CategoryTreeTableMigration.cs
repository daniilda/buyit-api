using FluentMigrator;

namespace ToxiCode.BuyIt.Api.Migrations.Migrations;

[Migration(2)]
public class CategoryTreeTableMigration : ForwardOnlyMigration
{
    public override void Up()
    {
        Create.Table("categories")
            .WithColumn("id").AsInt64().Identity().Unique()
            .WithColumn("name").AsString().NotNullable()
            .WithColumn("description").AsString().Nullable()
            .WithColumn("parent_category").AsInt64().Nullable().ForeignKey("categories", "id");

        Create.Table("items_category")
            .WithColumn("id").AsInt64().Identity().PrimaryKey().Unique()
            .WithColumn("item_id").AsInt64().NotNullable().ForeignKey("items", "id")
            .WithColumn("category_id").AsInt64().NotNullable().ForeignKey("categories", "id");

        Insert.IntoTable("categories")
            .Row(new { name = "Электроника", description = ""})
            .Row(new { name = "Одежда", description = ""})
            .Row(new { name = "Книги", description = ""});
    }
}