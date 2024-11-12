using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace vehicles_test_app.Migrations
{
    /// <inheritdoc />
    public partial class migrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AttributeValues_VehicleAttributes_VehicleAttributeId",
                table: "AttributeValues");

            migrationBuilder.DropIndex(
                name: "IX_AttributeValues_VehicleAttributeId",
                table: "AttributeValues");

            migrationBuilder.DropColumn(
                name: "VehicleAttributeId",
                table: "AttributeValues");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VehicleAttributeId",
                table: "AttributeValues",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AttributeValues_VehicleAttributeId",
                table: "AttributeValues",
                column: "VehicleAttributeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AttributeValues_VehicleAttributes_VehicleAttributeId",
                table: "AttributeValues",
                column: "VehicleAttributeId",
                principalTable: "VehicleAttributes",
                principalColumn: "Id");
        }
    }
}
