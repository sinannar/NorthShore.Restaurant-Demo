using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NorthShore.Restaurant.Migrations
{
    public partial class EntityCreationMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Foods",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Calorie = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    IsGlutenFree = table.Column<bool>(nullable: false),
                    IsDairyFree = table.Column<bool>(nullable: false),
                    IsNutFree = table.Column<bool>(nullable: false),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    DiscountRate = table.Column<decimal>(nullable: false),
                    TotalCalorie = table.Column<decimal>(nullable: false),
                    TotalPrice = table.Column<decimal>(nullable: false),
                    DiscountedPrice = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FoodMenuMappings",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FoodId = table.Column<long>(nullable: false),
                    MenuId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodMenuMappings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FoodMenuMapping_Food",
                        column: x => x.FoodId,
                        principalTable: "Foods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FoodMenuMapping_Mood",
                        column: x => x.MenuId,
                        principalTable: "Menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FoodMenuMappings_FoodId",
                table: "FoodMenuMappings",
                column: "FoodId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodMenuMappings_MenuId",
                table: "FoodMenuMappings",
                column: "MenuId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FoodMenuMappings");

            migrationBuilder.DropTable(
                name: "Foods");

            migrationBuilder.DropTable(
                name: "Menus");
        }
    }
}
