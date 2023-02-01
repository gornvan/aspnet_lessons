using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeaBusinessDAL.Migrations
{
    /// <inheritdoc />
    public partial class create : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Storage",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Storage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tea",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tea", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StorageModelTeaModel",
                columns: table => new
                {
                    StoragesStoringId = table.Column<long>(type: "bigint", nullable: false),
                    TeasStoredId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StorageModelTeaModel", x => new { x.StoragesStoringId, x.TeasStoredId });
                    table.ForeignKey(
                        name: "FK_StorageModelTeaModel_Storage_StoragesStoringId",
                        column: x => x.StoragesStoringId,
                        principalTable: "Storage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StorageModelTeaModel_Tea_TeasStoredId",
                        column: x => x.TeasStoredId,
                        principalTable: "Tea",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StorageModelTeaModel_TeasStoredId",
                table: "StorageModelTeaModel",
                column: "TeasStoredId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StorageModelTeaModel");

            migrationBuilder.DropTable(
                name: "Storage");

            migrationBuilder.DropTable(
                name: "Tea");
        }
    }
}
