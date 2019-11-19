using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ChefsDishes.Migrations
{
    public partial class Firstmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Chefs",
                columns: table => new
                {
                    id = table.Column<int>(type: "INT(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    first_name = table.Column<string>(type: "VARCHAR(40)", nullable: false),
                    last_name = table.Column<string>(type: "VARCHAR(40)", nullable: false),
                    birthdate = table.Column<DateTime>(nullable: false),
                    created_at = table.Column<DateTime>(nullable: false),
                    updated_at = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chefs", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Dishes",
                columns: table => new
                {
                    id = table.Column<int>(type: "INT(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    dish_name = table.Column<string>(type: "VARCHAR(40)", nullable: false),
                    taste_rating = table.Column<int>(type: "INT(1)", nullable: false),
                    calorie_amount = table.Column<int>(type: "INT(4)", nullable: false),
                    description = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    CreatorChefId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dishes", x => x.id);
                    table.ForeignKey(
                        name: "FK_Dishes_Chefs_CreatorChefId",
                        column: x => x.CreatorChefId,
                        principalTable: "Chefs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dishes_CreatorChefId",
                table: "Dishes",
                column: "CreatorChefId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dishes");

            migrationBuilder.DropTable(
                name: "Chefs");
        }
    }
}
