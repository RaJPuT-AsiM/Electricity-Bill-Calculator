using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bill_Portal.Migrations.Billing_Portal_Db_CRUD_
{
    public partial class tariffgrouptableadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tariff_groups",
                columns: table => new
                {
                    tariff_group_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tariff_group_code = table.Column<string>(nullable: true),
                    tariff_group_name = table.Column<string>(nullable: true),
                    current_status = table.Column<bool>(nullable: false),
                    date = table.Column<DateTime>(nullable: false),
                    notification_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tariff_groups", x => x.tariff_group_Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tariff_groups");
        }
    }
}
