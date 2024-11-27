using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WebProgrammingProject.Migrations
{
    /// <inheritdoc />
    public partial class First_Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Person_t",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    SurName = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person_t", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customer_t",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PersonalInfoId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer_t", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customer_t_Person_t_PersonalInfoId",
                        column: x => x.PersonalInfoId,
                        principalTable: "Person_t",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Shopkeeper_t",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PersonalInfoId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shopkeeper_t", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shopkeeper_t_Person_t_PersonalInfoId",
                        column: x => x.PersonalInfoId,
                        principalTable: "Person_t",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Shop_t",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    ShopkeeperId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shop_t", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shop_t_Shopkeeper_t_ShopkeeperId",
                        column: x => x.ShopkeeperId,
                        principalTable: "Shopkeeper_t",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Barber_t",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PersonalInfoId = table.Column<int>(type: "integer", nullable: false),
                    ShopId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Barber_t", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Barber_t_Person_t_PersonalInfoId",
                        column: x => x.PersonalInfoId,
                        principalTable: "Person_t",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Barber_t_Shop_t_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shop_t",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AvailableTime_t",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    start_t = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    end_t = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    availableTimeSpan = table.Column<TimeSpan>(type: "interval", nullable: false),
                    BarberId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvailableTime_t", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AvailableTime_t_Barber_t_BarberId",
                        column: x => x.BarberId,
                        principalTable: "Barber_t",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rendezvous_t",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    When = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CustomerId = table.Column<int>(type: "integer", nullable: false),
                    BarberId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rendezvous_t", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rendezvous_t_Barber_t_BarberId",
                        column: x => x.BarberId,
                        principalTable: "Barber_t",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rendezvous_t_Customer_t_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer_t",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AvailableTime_t_BarberId",
                table: "AvailableTime_t",
                column: "BarberId");

            migrationBuilder.CreateIndex(
                name: "IX_Barber_t_PersonalInfoId",
                table: "Barber_t",
                column: "PersonalInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Barber_t_ShopId",
                table: "Barber_t",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_t_PersonalInfoId",
                table: "Customer_t",
                column: "PersonalInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Rendezvous_t_BarberId",
                table: "Rendezvous_t",
                column: "BarberId");

            migrationBuilder.CreateIndex(
                name: "IX_Rendezvous_t_CustomerId",
                table: "Rendezvous_t",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Shop_t_ShopkeeperId",
                table: "Shop_t",
                column: "ShopkeeperId");

            migrationBuilder.CreateIndex(
                name: "IX_Shopkeeper_t_PersonalInfoId",
                table: "Shopkeeper_t",
                column: "PersonalInfoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AvailableTime_t");

            migrationBuilder.DropTable(
                name: "Rendezvous_t");

            migrationBuilder.DropTable(
                name: "Barber_t");

            migrationBuilder.DropTable(
                name: "Customer_t");

            migrationBuilder.DropTable(
                name: "Shop_t");

            migrationBuilder.DropTable(
                name: "Shopkeeper_t");

            migrationBuilder.DropTable(
                name: "Person_t");
        }
    }
}
