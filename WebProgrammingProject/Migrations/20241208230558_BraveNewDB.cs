using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WebProgrammingProject.Migrations
{
    /// <inheritdoc />
    public partial class BraveNewDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AvailableTime_t_Barber_t_BarberId",
                table: "AvailableTime_t");

            migrationBuilder.DropForeignKey(
                name: "FK_Barber_t_Person_t_PersonalInfoId",
                table: "Barber_t");

            migrationBuilder.DropForeignKey(
                name: "FK_Barber_t_Shop_t_ShopId",
                table: "Barber_t");

            migrationBuilder.DropForeignKey(
                name: "FK_Customer_t_Person_t_PersonalInfoId",
                table: "Customer_t");

            migrationBuilder.DropForeignKey(
                name: "FK_Rendezvous_t_Barber_t_BarberId",
                table: "Rendezvous_t");

            migrationBuilder.DropForeignKey(
                name: "FK_Rendezvous_t_Customer_t_CustomerId",
                table: "Rendezvous_t");

            migrationBuilder.DropForeignKey(
                name: "FK_Shop_t_Shopkeeper_t_ShopkeeperId",
                table: "Shop_t");

            migrationBuilder.DropForeignKey(
                name: "FK_Shopkeeper_t_Person_t_PersonId",
                table: "Shopkeeper_t");

            migrationBuilder.DropTable(
                name: "Person_t");

            migrationBuilder.DropIndex(
                name: "IX_Shopkeeper_t_PersonId",
                table: "Shopkeeper_t");

            migrationBuilder.DropIndex(
                name: "IX_Shop_t_ShopkeeperId",
                table: "Shop_t");

            migrationBuilder.DropIndex(
                name: "IX_Rendezvous_t_BarberId",
                table: "Rendezvous_t");

            migrationBuilder.DropIndex(
                name: "IX_Rendezvous_t_CustomerId",
                table: "Rendezvous_t");

            migrationBuilder.DropIndex(
                name: "IX_Customer_t_PersonalInfoId",
                table: "Customer_t");

            migrationBuilder.DropIndex(
                name: "IX_Barber_t_PersonalInfoId",
                table: "Barber_t");

            migrationBuilder.DropIndex(
                name: "IX_Barber_t_ShopId",
                table: "Barber_t");

            migrationBuilder.DropIndex(
                name: "IX_AvailableTime_t_BarberId",
                table: "AvailableTime_t");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "Shopkeeper_t");

            migrationBuilder.DropColumn(
                name: "PersonalInfoId",
                table: "Customer_t");

            migrationBuilder.DropColumn(
                name: "PersonalInfoId",
                table: "Barber_t");

            migrationBuilder.DropColumn(
                name: "Proficiencies",
                table: "Barber_t");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Shopkeeper_t",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Shopkeeper_t",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Shopkeeper_t",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SurName",
                table: "Shopkeeper_t",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Customer_t",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Customer_t",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Customer_t",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SurName",
                table: "Customer_t",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "ShopId",
                table: "Barber_t",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Barber_t",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Barber_t",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Barber_t",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SurName",
                table: "Barber_t",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Proficiencies_t",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    price = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proficiencies_t", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Proficiencies_t");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Shopkeeper_t");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Shopkeeper_t");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Shopkeeper_t");

            migrationBuilder.DropColumn(
                name: "SurName",
                table: "Shopkeeper_t");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Customer_t");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Customer_t");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Customer_t");

            migrationBuilder.DropColumn(
                name: "SurName",
                table: "Customer_t");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Barber_t");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Barber_t");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Barber_t");

            migrationBuilder.DropColumn(
                name: "SurName",
                table: "Barber_t");

            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "Shopkeeper_t",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PersonalInfoId",
                table: "Customer_t",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ShopId",
                table: "Barber_t",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "PersonalInfoId",
                table: "Barber_t",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<List<string>>(
                name: "Proficiencies",
                table: "Barber_t",
                type: "text[]",
                nullable: false);

            migrationBuilder.CreateTable(
                name: "Person_t",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Email = table.Column<string>(type: "text", nullable: false),
                    FirstName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    SurName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person_t", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Shopkeeper_t_PersonId",
                table: "Shopkeeper_t",
                column: "PersonId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Shop_t_ShopkeeperId",
                table: "Shop_t",
                column: "ShopkeeperId");

            migrationBuilder.CreateIndex(
                name: "IX_Rendezvous_t_BarberId",
                table: "Rendezvous_t",
                column: "BarberId");

            migrationBuilder.CreateIndex(
                name: "IX_Rendezvous_t_CustomerId",
                table: "Rendezvous_t",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_t_PersonalInfoId",
                table: "Customer_t",
                column: "PersonalInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Barber_t_PersonalInfoId",
                table: "Barber_t",
                column: "PersonalInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Barber_t_ShopId",
                table: "Barber_t",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_AvailableTime_t_BarberId",
                table: "AvailableTime_t",
                column: "BarberId");

            migrationBuilder.AddForeignKey(
                name: "FK_AvailableTime_t_Barber_t_BarberId",
                table: "AvailableTime_t",
                column: "BarberId",
                principalTable: "Barber_t",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Barber_t_Person_t_PersonalInfoId",
                table: "Barber_t",
                column: "PersonalInfoId",
                principalTable: "Person_t",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Barber_t_Shop_t_ShopId",
                table: "Barber_t",
                column: "ShopId",
                principalTable: "Shop_t",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_t_Person_t_PersonalInfoId",
                table: "Customer_t",
                column: "PersonalInfoId",
                principalTable: "Person_t",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rendezvous_t_Barber_t_BarberId",
                table: "Rendezvous_t",
                column: "BarberId",
                principalTable: "Barber_t",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rendezvous_t_Customer_t_CustomerId",
                table: "Rendezvous_t",
                column: "CustomerId",
                principalTable: "Customer_t",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Shop_t_Shopkeeper_t_ShopkeeperId",
                table: "Shop_t",
                column: "ShopkeeperId",
                principalTable: "Shopkeeper_t",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Shopkeeper_t_Person_t_PersonId",
                table: "Shopkeeper_t",
                column: "PersonId",
                principalTable: "Person_t",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
