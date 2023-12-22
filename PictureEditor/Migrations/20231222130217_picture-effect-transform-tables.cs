using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PictureEditor.Migrations
{
    /// <inheritdoc />
    public partial class pictureeffecttransformtables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Effects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Effects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pictures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EffectId = table.Column<int>(type: "int", nullable: false),
                    TransformId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pictures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pictures_Effects_EffectId",
                        column: x => x.EffectId,
                        principalTable: "Effects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transforms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Size = table.Column<int>(type: "int", nullable: false),
                    Crop = table.Column<int>(type: "int", nullable: false),
                    Radius = table.Column<double>(type: "float", nullable: false),
                    Horizontal = table.Column<bool>(type: "bit", nullable: false),
                    Vertical = table.Column<bool>(type: "bit", nullable: false),
                    PictureId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transforms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transforms_Pictures_PictureId",
                        column: x => x.PictureId,
                        principalTable: "Pictures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pictures_EffectId",
                table: "Pictures",
                column: "EffectId");

            migrationBuilder.CreateIndex(
                name: "IX_Pictures_TransformId",
                table: "Pictures",
                column: "TransformId");

            migrationBuilder.CreateIndex(
                name: "IX_Transforms_PictureId",
                table: "Transforms",
                column: "PictureId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pictures_Transforms_TransformId",
                table: "Pictures",
                column: "TransformId",
                principalTable: "Transforms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pictures_Effects_EffectId",
                table: "Pictures");

            migrationBuilder.DropForeignKey(
                name: "FK_Pictures_Transforms_TransformId",
                table: "Pictures");

            migrationBuilder.DropTable(
                name: "Effects");

            migrationBuilder.DropTable(
                name: "Transforms");

            migrationBuilder.DropTable(
                name: "Pictures");
        }
    }
}
