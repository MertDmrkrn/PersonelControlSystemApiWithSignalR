using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig_relation_location_personel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LocationID",
                table: "Personels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Personels_LocationID",
                table: "Personels",
                column: "LocationID");

            migrationBuilder.AddForeignKey(
                name: "FK_Personels_Locations_LocationID",
                table: "Personels",
                column: "LocationID",
                principalTable: "Locations",
                principalColumn: "LocationID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personels_Locations_LocationID",
                table: "Personels");

            migrationBuilder.DropIndex(
                name: "IX_Personels_LocationID",
                table: "Personels");

            migrationBuilder.DropColumn(
                name: "LocationID",
                table: "Personels");
        }
    }
}
