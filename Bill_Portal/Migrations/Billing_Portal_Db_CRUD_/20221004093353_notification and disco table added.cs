using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bill_Portal.Migrations.Billing_Portal_Db_CRUD_
{
    public partial class notificationanddiscotableadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "notifications",
                columns: table => new
                {
                    notification_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    notification_serial = table.Column<string>(nullable: true),
                    notification_title = table.Column<string>(nullable: true),
                    notification_document = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_notifications", x => x.notification_id);
                });

            migrationBuilder.CreateTable(
                name: "discos",
                columns: table => new
                {
                    disco_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    disco_name = table.Column<string>(nullable: true),
                    current_status = table.Column<bool>(nullable: false),
                    date = table.Column<DateTime>(nullable: false),
                    notification_id = table.Column<int>(nullable: false),
                    disco_notificationnotification_id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_discos", x => x.disco_id);
                    table.ForeignKey(
                        name: "FK_discos_notifications_disco_notificationnotification_id",
                        column: x => x.disco_notificationnotification_id,
                        principalTable: "notifications",
                        principalColumn: "notification_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_discos_disco_notificationnotification_id",
                table: "discos",
                column: "disco_notificationnotification_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "discos");

            migrationBuilder.DropTable(
                name: "notifications");
        }
    }
}
