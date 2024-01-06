using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FloodChasersLogic.Migrations
{
    /// <inheritdoc />
    public partial class AlertsWithLocation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LocationId",
                table: "Alerts",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alerts_LocationId",
                table: "Alerts",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alerts_Location_LocationId",
                table: "Alerts",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alerts_Location_LocationId",
                table: "Alerts");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropIndex(
                name: "IX_Alerts_LocationId",
                table: "Alerts");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Alerts");
        }
    }
}
