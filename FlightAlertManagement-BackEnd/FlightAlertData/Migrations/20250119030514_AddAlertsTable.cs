using Microsoft.EntityFrameworkCore.Migrations;

namespace FlightAlertData.Migrations
{
    public partial class AddAlertsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "alerts",
                columns: table => new
                {
                    alert_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(nullable: false),
                    flight_source = table.Column<string>(maxLength: 255, nullable: false),
                    flight_destination = table.Column<string>(maxLength: 255, nullable: false),
                    price_threshold = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    is_active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__alerts__4B8FB03A003DD2E6", x => x.alert_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "alerts");
        }
    }
}
