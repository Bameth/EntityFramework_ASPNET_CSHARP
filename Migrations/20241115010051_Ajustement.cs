using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace web.Migrations
{
    /// <inheritdoc />
    public partial class Ajustement : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Paiements_Details_DetailId",
                table: "Paiements");

            migrationBuilder.DropIndex(
                name: "IX_Paiements_DetailId",
                table: "Paiements");

            migrationBuilder.DropColumn(
                name: "DetailId",
                table: "Paiements");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DetailId",
                table: "Paiements",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Paiements_DetailId",
                table: "Paiements",
                column: "DetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_Paiements_Details_DetailId",
                table: "Paiements",
                column: "DetailId",
                principalTable: "Details",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
