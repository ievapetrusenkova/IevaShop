using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IevaShop.Migrations
{
    public partial class InitialDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AllClothings_Men_MenId",
                table: "AllClothings");

            migrationBuilder.DropForeignKey(
                name: "FK_AllClothings_Women_WomenId",
                table: "AllClothings");

            migrationBuilder.DropTable(
                name: "Men");

            migrationBuilder.DropTable(
                name: "Women");

            migrationBuilder.DropIndex(
                name: "IX_AllClothings_MenId",
                table: "AllClothings");

            migrationBuilder.DropColumn(
                name: "MenId",
                table: "AllClothings");

            migrationBuilder.RenameColumn(
                name: "WomenId",
                table: "AllClothings",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_AllClothings_WomenId",
                table: "AllClothings",
                newName: "IX_AllClothings_CategoryId");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_AllClothings_Categories_CategoryId",
                table: "AllClothings",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AllClothings_Categories_CategoryId",
                table: "AllClothings");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "AllClothings",
                newName: "WomenId");

            migrationBuilder.RenameIndex(
                name: "IX_AllClothings_CategoryId",
                table: "AllClothings",
                newName: "IX_AllClothings_WomenId");

            migrationBuilder.AddColumn<int>(
                name: "MenId",
                table: "AllClothings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Men",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Men", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Women",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Women", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AllClothings_MenId",
                table: "AllClothings",
                column: "MenId");

            migrationBuilder.AddForeignKey(
                name: "FK_AllClothings_Men_MenId",
                table: "AllClothings",
                column: "MenId",
                principalTable: "Men",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AllClothings_Women_WomenId",
                table: "AllClothings",
                column: "WomenId",
                principalTable: "Women",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
