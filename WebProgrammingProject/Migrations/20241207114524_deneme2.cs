using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebProgrammingProject.Migrations
{
    /// <inheritdoc />
    public partial class deneme2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Person_t_Shopkeeper_t_ShopkeeperId",
                table: "Person_t");

            migrationBuilder.DropIndex(
                name: "IX_Person_t_ShopkeeperId",
                table: "Person_t");

            migrationBuilder.DropColumn(
                name: "ShopkeeperId",
                table: "Person_t");

            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "Shopkeeper_t",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Shopkeeper_t_PersonId",
                table: "Shopkeeper_t",
                column: "PersonId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Shopkeeper_t_Person_t_PersonId",
                table: "Shopkeeper_t",
                column: "PersonId",
                principalTable: "Person_t",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shopkeeper_t_Person_t_PersonId",
                table: "Shopkeeper_t");

            migrationBuilder.DropIndex(
                name: "IX_Shopkeeper_t_PersonId",
                table: "Shopkeeper_t");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "Shopkeeper_t");

            migrationBuilder.AddColumn<int>(
                name: "ShopkeeperId",
                table: "Person_t",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Person_t_ShopkeeperId",
                table: "Person_t",
                column: "ShopkeeperId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Person_t_Shopkeeper_t_ShopkeeperId",
                table: "Person_t",
                column: "ShopkeeperId",
                principalTable: "Shopkeeper_t",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
