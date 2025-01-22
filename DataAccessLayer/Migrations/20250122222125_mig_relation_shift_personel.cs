using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig_relation_shift_personel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ShiftID",
                table: "Personels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Personels_ShiftID",
                table: "Personels",
                column: "ShiftID");

            migrationBuilder.AddForeignKey(
                name: "FK_Personels_Shifts_ShiftID",
                table: "Personels",
                column: "ShiftID",
                principalTable: "Shifts",
                principalColumn: "ShiftID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personels_Shifts_ShiftID",
                table: "Personels");

            migrationBuilder.DropIndex(
                name: "IX_Personels_ShiftID",
                table: "Personels");

            migrationBuilder.DropColumn(
                name: "ShiftID",
                table: "Personels");
        }
    }
}
